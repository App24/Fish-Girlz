using System.Linq;
using UnityEngine;

namespace UnityEditor.Tilemaps{
    /// <summary>
    /// This Brush instances and places a containing prefab onto the targeted location and parents the instanced object to the paint target.
    /// </summary>
    [CreateAssetMenu(fileName = "New Prefab Brush", menuName = "App24/Brushes/Prefabs Brush")]
    [CustomGridBrush(false, true, false, "Prefab Brush")]
    public class PrefabsBrush : BasePrefabBrush
    {
        private const float k_PerlinOffset = 100000f;

            #pragma warning disable 0649
            /// <summary>
            /// The index of Prefab to paint
            /// </summary>
            [SerializeField] int m_SelectedIndex=0;

            /// <summary>
            /// The selection of Prefabs to paint from
            /// </summary>
            [SerializeField] GameObject[] m_Prefabs;
            #pragma warning restore 0649

            /// <summary>
            /// If true, erases any GameObjects that are in a given position within the selected layers with Erasing.
            /// Otherwise, erases only GameObjects that are created from owned Prefab in a given position within the selected layers with Erasing.
            /// </summary>
            bool m_EraseAnyObjects;

            /// <summary>
            /// If true, replaces any GameObjects that are in a given position within the selected layers with Paiting.
            /// </summary>
            bool m_ReplaceAnyObjects;

            /// <summary>
            /// Paints GameObject from containg Prefabs with randomly into a given position within the selected layers.
            /// The PrefabRandomBrush overrides this to provide Prefab painting functionality.
            /// </summary>
            /// <param name="grid">Grid used for layout.</param>
            /// <param name="brushTarget">Target of the paint operation. By default the currently selected GameObject.</param>
            /// <param name="position">The coordinates of the cell to paint data to.</param>
            public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
            {
                // Do not allow editing palettes
                if (brushTarget.layer == 31 || brushTarget == null)
                {
                    return;
                }

                var objectsInCell = GetObjectsInCell(grid, brushTarget.transform, position);
                var existPrefabObjectInCell = objectsInCell.Any(objectInCell =>
                {
                    return m_Prefabs.Any(prefab => PrefabUtility.GetCorrespondingObjectFromSource(objectInCell) == prefab);
                });
                if(m_ReplaceAnyObjects){
                    foreach(GameObject objectInCell in objectsInCell){
                        Undo.DestroyObjectImmediate(objectInCell);
                    }
                }

                if (!existPrefabObjectInCell||m_ReplaceAnyObjects)
                {
                    if(m_SelectedIndex>=m_Prefabs.Length) return;
                    var prefab = m_Prefabs[m_SelectedIndex];
                    base.InstantiatePrefabInCell(grid, brushTarget, position, prefab);
                }
            }

        public override void BoxFill(GridLayout grid, GameObject brushTarget, BoundsInt positions)
        {
            if (brushTarget.layer == 31 || brushTarget == null)
            {
                return;
            }
            foreach (var position in positions.allPositionsWithin)
            {
                var objectsInCell = GetObjectsInCell(grid, brushTarget.transform, position);
                var existPrefabObjectInCell = objectsInCell.Any(objectInCell =>
                {
                    return m_Prefabs.Any(prefab => PrefabUtility.GetCorrespondingObjectFromSource(objectInCell) == prefab);
                });
                if(m_ReplaceAnyObjects){
                    foreach(GameObject objectInCell in objectsInCell){
                        Undo.DestroyObjectImmediate(objectInCell);
                    }
                }

                if (!existPrefabObjectInCell||m_ReplaceAnyObjects)
                {
                    if(m_SelectedIndex>=m_Prefabs.Length) return;
                    var prefab = m_Prefabs[m_SelectedIndex];
                    base.InstantiatePrefabInCell(grid, brushTarget, position, prefab);
                }
            }
            
            //base.BoxFill(grid, brushTarget, positions);
        }


        /// <summary>
        /// If "Erase Any Objects" is true, erases any GameObjects that are in a given position within the selected layers.
        /// If "Erase Any Objects" is false, erases only GameObjects that are created from owned Prefab in a given position within the selected layers.
        /// The PrefabRandomBrush overrides this to provide Prefab erasing functionality.
        /// </summary>
        /// <param name="grid">Grid used for layout.</param>
        /// <param name="brushTarget">Target of the erase operation. By default the currently selected GameObject.</param>
        /// <param name="position">The coordinates of the cell to erase data from.</param>
        public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget.layer == 31 || brushTarget.transform == null)
            {
                return;
            }

            foreach (var objectInCell in GetObjectsInCell(grid, brushTarget.transform, position))
            {
                foreach (var prefab in m_Prefabs)
                {
                    if (objectInCell != null && (m_EraseAnyObjects || PrefabUtility.GetCorrespondingObjectFromSource(objectInCell) == prefab))
                    {
                        Undo.DestroyObjectImmediate(objectInCell);
                    }
                }
            }
        }

        /// <summary>
        /// The Brush Editor for a Prefab Brush.
        /// </summary>
        [CustomEditor(typeof(PrefabsBrush))]
        public class PrefabsBrushEditor : BasePrefabBrushEditor
        {
            private PrefabsBrush prefabsBrush => target as PrefabsBrush;

            private SerializedProperty m_Prefabs;

            protected override void OnEnable()
            {
                base.OnEnable();
                m_Prefabs = m_SerializedObject.FindProperty("m_Prefabs");
            }

            /// <summary>
            /// Callback for painting the inspector GUI for the PrefabBrush in the Tile Palette.
            /// The PrefabBrush Editor overrides this to have a custom inspector for this Brush.
            /// </summary>
            public override void OnPaintInspectorGUI()
            {
                base.OnPaintInspectorGUI();
                m_SerializedObject.UpdateIfRequiredOrScript();
                prefabsBrush.m_SelectedIndex = EditorGUILayout.IntField("Selected Index", prefabsBrush.m_SelectedIndex);
                EditorGUILayout.PropertyField(m_Prefabs, true);
                prefabsBrush.m_ReplaceAnyObjects = EditorGUILayout.Toggle("Replace Any Objects", prefabsBrush.m_ReplaceAnyObjects);
                prefabsBrush.m_EraseAnyObjects = EditorGUILayout.Toggle("Erase Any Objects", prefabsBrush.m_EraseAnyObjects);
                m_SerializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }
    }
}