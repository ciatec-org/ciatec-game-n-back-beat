# Ritmo

Jogo sério terapêutico baseado no **N-Back Task**, para crianças e jovens no espectro autista (TEA). O jogador escuta sequências sonoras marcadas por um metrônomo e responde se um estímulo ocorreu *N* passos atrás, exercitando memória de trabalho e atenção.

Projeto do **CIATec**, vinculado ao **ATGCP**. Documento de referência: *SGDD - Ritmo* (em `docs/`).

| | |
| --- | --- |
| **Engine** | Unity (C#) |
| **Backend adaptativo** | Python + FastAPI |
| **Plataformas** | WebGL, Desktop (Linux/Windows), Mobile |
| **Interação** | Mouse ou toque |
| **Público** | TEA, perfis de Suporte 1, 2 e 3 (S3 com mediação clínica) |

## Como o jogo funciona

1. **Perfil:** o jogador indica o humor e escolhe o estímulo (gênero musical ou ruído).
2. **Treino:** tutorial pulável (S1), demonstração animada (S2) ou *Treino Pré-Jogo* N=0 sem cronômetro (S3).
3. **Jogo:** a música toca em *timestamps*; ao fim de cada ciclo, o jogador responde **Sim/Não** a "este estímulo ocorreu N passos atrás?". São 3 tentativas por fase; ao zerar, o mesmo trecho é reescutado.
4. **Fim:** pontuação só de acertos e a música completa como recompensa.

**Feedback:** acerto recebe reforço contido; erro é **neutro** (sem som de falha nem mudança brusca de cor).

**Dificuldade adaptativa:** o backend ajusta N e BPM (60 a 120) entre as fases. O terapeuta pode **travar N/BPM** ou acionar uma **interrupção branda** (próxima pergunta vira treino N=0).

## Arquitetura

```
Unity (C#)  ──── telemetria JSON/REST ────▶  FastAPI (Python)
 jogo, áudio,  ◀──── parâmetros da fase ────  motor adaptativo
 UI, fallback local
```

- O cronômetro e o metrônomo rodam **localmente** (`AudioSettings.dspTime`). A rede só é usada **entre fases**.
- Sem rede, o `LocalRuleProvider` aplica as regras de segurança e a telemetria é reenviada depois.
- A trava do mediador sempre prevalece sobre o algoritmo.

## Estrutura

A raiz do repositório é o próprio projeto Unity.
 
```
.
├── Assets/
│   ├── _Project/
│   │   ├── Scripts/            # Core, Audio, NBack, Adaptive, Mediator, Profiles,
│   │   │                       # Training, Feedback, Session, Telemetry, Reports, UI
│   │   ├── ScriptableObjects/  # Tracks, Stimuli, Profiles, PhaseSettings, SafetyLimits
│   │   ├── Scenes/             # Bootstrap, Profile, Training, Gameplay, SessionEnd
│   │   ├── Prefabs/
│   │   └── Tests/              # EditMode, PlayMode, Performance
│   ├── Plugins/
│   └── ThirdParty/
├── Docs/                       # SGDD, PPI, protocolo
├── Packages/
├── ProjectSettings/
├── .gitattributes
├── .gitignore
└── README.md
```

O backend FastAPI (motor adaptativo) não faz parte deste repositório: **[definir onde ficará]**.
 
Parâmetros terapêuticos (N, BPM, duração, tentativas) ficam em `ScriptableObjects`, nunca no código.


## Assembly Definitions

Cada módulo tem seu `.asmdef`. A regra principal: **a lógica clínica (`NBack`, `Adaptive`) nunca referencia `UI`.**

| Assembly | Depende de |
| --- | --- |
| `Ritmo.Core` | nenhum |
| `Ritmo.Audio` | Core |
| `Ritmo.NBack` | Core, Audio |
| `Ritmo.Adaptive` | Core, NBack |
| `Ritmo.Telemetry` | Core |
| `Ritmo.Profiles`, `Ritmo.Feedback` | Core |
| `Ritmo.Training` | Core, NBack, Feedback, Profiles |
| `Ritmo.Mediator` | Core, NBack, Adaptive |
| `Ritmo.Session` | Core, NBack, Adaptive, Profiles, Telemetry, Feedback |
| `Ritmo.Reports` | Core, Telemetry |
| `Ritmo.UI` | Core, NBack, Profiles, Feedback, Mediator |

## Convenções

- Código e pastas em **inglês**; textos do jogo em **PT-BR**.
- Prefixos: `PRE_` (prefabs), `SO_` (ScriptableObjects), `M_` (materiais), `T_` (texturas), `ANIM_` (animações).
- Feedback de erro nunca reutiliza sons ou efeitos de acerto.
- Toda mecânica nova deve citar o Guiding Principle (GP-01 a GP-05) do SGDD que a justifica.

## Segurança e privacidade

- Fundo neutro por padrão, volume mestre sempre acessível e botões com no mínimo 48x48 dp.
- Jogável sentado; sessões com limite de duração e critérios de interrupção.
- Os dados são de saúde de menores: aplicar **LGPD** (consentimento dos responsáveis, anonimização e criptografia).

## Pendências

Uso domiciliar de S2 sem supervisão, direitos autorais das músicas, desempenho em tablets de baixo custo e latência Unity–FastAPI (SGDD, seção 13). As hipóteses H-01 a H-04 serão validadas no Doc 3.
