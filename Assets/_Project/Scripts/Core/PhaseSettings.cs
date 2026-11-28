using UnityEngine;

namespace Ritmo.Core
{
    [CreateAssetMenu(fileName = "PhaseSettings", menuName = "Ritmo/Phase Settings")]
    public sealed class PhaseSettings : ScriptableObject
    {
        // Faixas do SGDD (§11.1, §5.2) e das lacunas L-05, L-12, L-34 e US-07.6 do ABD.
        public const int MinN = 0;
        public const int MaxN = 3;
        public const int MinBlocks = 4;
        public const int MaxBlocks = 12;
        public const int MinAttempts = 1;
        public const int MaxAttempts = 5;
        public const int MinBpm = 60;
        public const int MaxBpm = 120;
        public const int MinProbes = 1;
        public const int MaxProbes = 5;
        public const int MinDistinctStimuli = 3;
        public const int MaxDistinctStimuli = 5;
        public const float MinResponseTimeSeconds = 5f;
        public const float MaxResponseTimeSeconds = 20f;

        [SerializeField] private int n = 1;
        [SerializeField] private int blocksPerPhase = 6;
        [SerializeField] private int attempts = 3;
        [SerializeField] private int bpm = 60;
        [SerializeField] private int probesPerPhase = 3;
        [SerializeField] private int distinctStimuli = 5;
        [SerializeField] private float responseTimeSeconds = 10f;

        public int N => n;
        public int BlocksPerPhase => blocksPerPhase;
        public int Attempts => attempts;
        public int Bpm => bpm;
        public int ProbesPerPhase => probesPerPhase;
        public int DistinctStimuli => distinctStimuli;
        public float ResponseTimeSeconds => responseTimeSeconds;

        // Valor fora da faixa vai ao limite; o asset nunca fica inválido.
        private void OnValidate()
        {
            n = Mathf.Clamp(n, MinN, MaxN);
            blocksPerPhase = Mathf.Clamp(blocksPerPhase, MinBlocks, MaxBlocks);
            attempts = Mathf.Clamp(attempts, MinAttempts, MaxAttempts);
            bpm = Mathf.Clamp(bpm, MinBpm, MaxBpm);
            probesPerPhase = Mathf.Clamp(probesPerPhase, MinProbes, MaxProbes);
            distinctStimuli = Mathf.Clamp(distinctStimuli, MinDistinctStimuli, MaxDistinctStimuli);
            responseTimeSeconds = Mathf.Clamp(responseTimeSeconds, MinResponseTimeSeconds, MaxResponseTimeSeconds);
        }
    }
}
