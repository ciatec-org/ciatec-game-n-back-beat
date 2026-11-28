using System;
using System.Reflection;
using NUnit.Framework;
using Ritmo.Core;
using UnityEngine;

namespace Ritmo.Tests.EditMode
{
    public class PhaseSettingsTests
    {
        private const BindingFlags Privado = BindingFlags.NonPublic | BindingFlags.Instance;

        private PhaseSettings settings;

        [SetUp]
        public void SetUp()
        {
            settings = ScriptableObject.CreateInstance<PhaseSettings>();
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(settings);
        }

        private void Definir(string campo, object valor)
        {
            FieldInfo field = typeof(PhaseSettings).GetField(campo, Privado);
            Assert.IsNotNull(field, $"Campo não encontrado: {campo}");
            field.SetValue(settings, Convert.ChangeType(valor, field.FieldType));
        }

        private double Ler(string campo)
        {
            FieldInfo field = typeof(PhaseSettings).GetField(campo, Privado);
            Assert.IsNotNull(field, $"Campo não encontrado: {campo}");
            return Convert.ToDouble(field.GetValue(settings));
        }

        private void Validar()
        {
            MethodInfo onValidate = typeof(PhaseSettings).GetMethod("OnValidate", Privado);
            Assert.IsNotNull(onValidate, "OnValidate não encontrado.");
            onValidate.Invoke(settings, null);
        }

        [Test]
        public void Padroes_SaoOsDeEntradaDoS1()
        {
            Assert.AreEqual(1, settings.N);
            Assert.AreEqual(6, settings.BlocksPerPhase);
            Assert.AreEqual(3, settings.Attempts);
            Assert.AreEqual(60, settings.Bpm);
            Assert.AreEqual(3, settings.ProbesPerPhase);
            Assert.AreEqual(5, settings.DistinctStimuli);
            Assert.AreEqual(10f, settings.ResponseTimeSeconds);
        }

        [Test]
        public void ValorDentroDaFaixa_Permanece()
        {
            Definir("n", 2);
            Definir("bpm", 90);

            Validar();

            Assert.AreEqual(2, settings.N);
            Assert.AreEqual(90, settings.Bpm);
        }

        [Test]
        public void BpmAcimaDaFaixa_VaiA120()
        {
            Definir("bpm", 150);

            Validar();

            Assert.AreEqual(120, settings.Bpm);
        }

        [TestCase("n", -1, 0)]
        [TestCase("n", 4, 3)]
        [TestCase("blocksPerPhase", 3, 4)]
        [TestCase("blocksPerPhase", 13, 12)]
        [TestCase("attempts", 0, 1)]
        [TestCase("attempts", 6, 5)]
        [TestCase("bpm", 59, 60)]
        [TestCase("bpm", 150, 120)]
        [TestCase("probesPerPhase", 0, 1)]
        [TestCase("probesPerPhase", 6, 5)]
        [TestCase("distinctStimuli", 2, 3)]
        [TestCase("distinctStimuli", 6, 5)]
        [TestCase("responseTimeSeconds", 4f, 5f)]
        [TestCase("responseTimeSeconds", 21f, 20f)]
        public void ValorForaDaFaixa_VaiAoLimite(string campo, object entrada, object esperado)
        {
            Definir(campo, entrada);

            Validar();

            Assert.AreEqual(Convert.ToDouble(esperado), Ler(campo), 0.0001);
        }

        [TestCase("n", 0)]
        [TestCase("n", 3)]
        [TestCase("blocksPerPhase", 4)]
        [TestCase("blocksPerPhase", 12)]
        [TestCase("attempts", 1)]
        [TestCase("attempts", 5)]
        [TestCase("bpm", 60)]
        [TestCase("bpm", 120)]
        [TestCase("probesPerPhase", 1)]
        [TestCase("probesPerPhase", 5)]
        [TestCase("distinctStimuli", 3)]
        [TestCase("distinctStimuli", 5)]
        [TestCase("responseTimeSeconds", 5f)]
        [TestCase("responseTimeSeconds", 20f)]
        public void ValorNoLimite_Permanece(string campo, object limite)
        {
            Definir(campo, limite);

            Validar();

            Assert.AreEqual(Convert.ToDouble(limite), Ler(campo), 0.0001);
        }
    }
}
