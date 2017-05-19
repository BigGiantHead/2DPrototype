using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// View that is bound to the BattleViewModel context.
    /// </summary>
    public class BattleView : TypedView<BattleViewModel>
    {
        /// <summary>
        /// Reference to the coroutine that executes the automatic battle scenario.
        /// </summary>
        private Coroutine doScenario;

        /// <summary>
        /// Reference to the context.
        /// </summary>
        [Tooltip("Reference to the context.")]
        private BattleViewModel context = null;

        /// <summary>
        /// Button that loads the menu context.
        /// </summary>
        [SerializeField]
        [Tooltip("Button that loads the menu context.")]
        private Button exitButton;

        /// <summary>
        /// Button that resets the battle.
        /// </summary>
        [SerializeField]
        [Tooltip("Button that resets the battle.")]
        private Button resetButton;

        /// <summary>
        /// The minimum that the automatic scenario will wait between actions.
        /// </summary>
        [SerializeField]
        [Tooltip("The minimum that the automatic scenario will wait between actions.")]
        private float minimumScenarioActionWait = 1f;

        /// <summary>
        /// Reference to the fighter view prefab.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the fighter view prefab.")]
        private GameObject fighterViewPrefab = null;

        public override void BindToContext(BattleViewModel context)
        {
            this.context = context;

            if (context != null)
            {
                //Create the fighters
                InstantiateFighters();
                
                context.Battle.OnBattleFinished += OnBattleFinished;

                exitButton.onClick.AddListener(() =>
                {
                    context.BackToMenu();
                });

                resetButton.onClick.AddListener(() =>
                {
                    StartScenario();
                    context.ResetBattle();
                });

                //Start the automatic scenario
                StartScenario();
            }
        }

        /// <summary>
        /// Creates 2 FighterViews in the scene and binds them to needed context.
        /// </summary>
        private void InstantiateFighters()
        {
            //instatiate left
            GameObject go = Instantiate(fighterViewPrefab, transform);
            go.transform.localPosition = new Vector3(-2.5f, 0, 0);
            FighterView fighterView = go.GetComponent<FighterView>();
            fighterView.BindToContext(context.Battle.Left);

            //instatiate right
            go = Instantiate(fighterViewPrefab, transform);
            go.transform.localPosition = new Vector3(2.5f, 0, 0);
            go.transform.localScale = new Vector3(-1f, 1f, 1f);
            fighterView = go.GetComponent<FighterView>();
            fighterView.BindToContext(context.Battle.Right);
        }

        /// <summary>
        /// Start the battle scenario.
        /// </summary>
        private void StartScenario()
        {
            StopScenerio();
            doScenario = StartCoroutine(DoScenario());
        }

        /// <summary>
        /// Stop the battle scenerio.
        /// </summary>
        private void StopScenerio()
        {
            if (doScenario != null)
            {
                StopCoroutine(doScenario);
                doScenario = null;
            }
        }

        /// <summary>
        /// When the battle finishes stop the automated scenario.
        /// </summary>
        /// <param name="victor">The victorious fighter.</param>
        private void OnBattleFinished(Fighter victor)
        {
            StopScenerio();
        }

        /// <summary>
        /// The coroutine that executes an automatic scenario.
        /// </summary>
        /// <returns></returns>
        private IEnumerator DoScenario()
        {
            yield return new WaitForSeconds(2);

            while (true)
            {
                int fighter = Random.Range(0, 2);
                if (fighter == 0)
                {
                    context.LeftAttack();
                }
                else
                {
                    context.RightAttack();
                }

                yield return new WaitForSeconds(Random.value * 2f + minimumScenarioActionWait);
            }
        }
    }
}
