using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Ritmo.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Ritmo.Tests.PlayMode
{
    public class BootstrapSmokeTests
    {
        private GameObject bootstrapObject;

        [TearDown]
        public void TearDown()
        {
            BootstrapLoader.LoadAction = SceneLoader.Load;

            if (bootstrapObject != null)
            {
                Object.Destroy(bootstrapObject);
            }
        }

        [Test]
        public void SceneNames_ContemAsCincoCenasNaOrdemDoFluxo()
        {
            string[] esperadas =
            {
                "00_Bootstrap",
                "01_Profile",
                "02_Training",
                "03_Gameplay",
                "04_SessionEnd"
            };

            Assert.AreEqual(esperadas, SceneNames.AllOrdered);
            Assert.AreEqual("00_Bootstrap", SceneNames.Bootstrap);
            Assert.AreEqual("01_Profile", SceneNames.Profile);
            Assert.AreEqual("02_Training", SceneNames.Training);
            Assert.AreEqual("03_Gameplay", SceneNames.Gameplay);
            Assert.AreEqual("04_SessionEnd", SceneNames.SessionEnd);
        }

        [UnityTest]
        public IEnumerator BootstrapLoader_AoIniciar_CarregaTelaInicialSemPassoManual()
        {
            string cenaCarregada = null;
            BootstrapLoader.LoadAction = nome => cenaCarregada = nome;

            bootstrapObject = new GameObject("Bootstrap");
            bootstrapObject.AddComponent<BootstrapLoader>();

            yield return null;

            Assert.AreEqual(SceneNames.Profile, cenaCarregada);
        }

        [Test]
        public void BuildSettings_ContemAsCincoCenasNaOrdemESemSampleScene()
        {
            int total = SceneManager.sceneCountInBuildSettings;
            var cenasNoBuild = new List<string>(total);

            for (int i = 0; i < total; i++)
            {
                string caminho = SceneUtility.GetScenePathByBuildIndex(i);
                string nome = Path.GetFileNameWithoutExtension(caminho);
                cenasNoBuild.Add(nome);
            }

            Assert.IsFalse(
                cenasNoBuild.Contains("SampleScene"),
                "SampleScene ainda está registrada no Build Settings."
            );

            foreach (string cenaEsperada in SceneNames.AllOrdered)
            {
                Assert.IsTrue(
                    cenasNoBuild.Contains(cenaEsperada),
                    $"Cena ausente no Build Settings: {cenaEsperada}"
                );
            }

            for (int i = 0; i < SceneNames.AllOrdered.Length; i++)
            {
                Assert.AreEqual(
                    SceneNames.AllOrdered[i],
                    cenasNoBuild[i],
                    $"Ordem incorreta no Build Settings na posição {i}. Esperado: {SceneNames.AllOrdered[i]}, encontrado: {cenasNoBuild[i]}"
                );
            }
        }
    }
}
