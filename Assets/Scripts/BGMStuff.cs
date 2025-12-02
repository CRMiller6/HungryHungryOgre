using UnityEngine;
using TMPro; // For the standard UI Dropdown
    // using TMPro; // If using TextMeshPro Dropdown

    public class BGMSuff : MonoBehaviour
    {
        public TMP_Dropdown myDropdown; // Assign this in the Inspector
         
        public void DropDown(int index)
        {
            
            switch (index)
            {
                case 0:
                //audio1
                break;
                case 1:
                //audio2 
                break;
                case 2:
                //nothing
                break;
            }

            
        }
    }