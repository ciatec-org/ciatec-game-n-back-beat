# Registro do progresso, para cada task estabelecida no backlog

## US-01.1 / T-01.1.1: cenas e Bootstrap
- Classes: SceneNames, SceneLoader, BootstrapLoader (Ritmo.Core). Testes: BootstrapSmokeTests (PlayMode), 3 verdes.
- Montado no Editor: 5 cenas em Assets/_Project/Scenes/; 00_Bootstrap tem o GameObject Bootstrap com BootstrapLoader (sem campos); Build Profiles com as 5 cenas na ordem e sem SampleScene.
- Conferido no Play: 00_Bootstrap abre a 01_Profile sem passo manual.
- Falta para a story: T-01.1.2 (PhaseSettings + asset do S1 + teste EditMode do limite de BPM) e T-01.1.3 (ícones).

## US-01.2 / T-01.1.2: PhaseSettings
- Classe: PhaseSettings (Ritmo.Core). Testes: PhaseSettingsTests (EditMode).
- Faixas no OnValidate: N 0-3, blocos 4-12, tentativas 1-5, BPM 60-120, sondas 1-5, distintos 3-5, resposta 5-20 s.
- Lacunas: nenhuma. Tentativas 1-5 vêm da US-07.6; distintos, da L-34; resposta, da L-12.
- Aluno monta: asset PhaseSettings em Assets/_Project/ScriptableObjects/PhaseSettings/ com os valores do S1 e confere que BPM 150 volta a 120.
- Falta: T-01.1.3 (ícones).
