using HexFlip.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HexFlip.Helper
{
    public class PositionHelper
    {
        public static GridPosition WorldToGridPosition(Vector3 worldposition)
        {
            //DONE: Convert Inworld position to gridposition!

            //fixing world position scaling
            Vector3 scaleWorldPosition = worldposition / 1;

            //Calculation of the rowcordinat
            int r = Mathf.RoundToInt(scaleWorldPosition.z * 0.65f); /* 0.65 verwijst naar de breedte van de tile.
                                                                     * tiles staan in een rij dus naast elkaar waardoor de afstand makkelijk te brekennen is 
                                                                     * door het gebruiken van 0.65
                                                                     */

            //Colom Calculator: Used to make the conversion from double width to axial coordinates
            int colom = Mathf.RoundToInt((scaleWorldPosition.x - (Mathf.Abs(r % 2) * (Mathf.Sqrt(3) / 2)))/ Mathf.Sqrt(3));  /* (Mathf.Abs(r % 2) => om te checken of de tiles onder elkaar staan | 
                                                                                                                              * indien de uitkomst van deze formule 0 is wil dit zeggen dat de tiles onder 
                                                                                                                              * elkaar staan.
                                                                                                                              * 
                                                                                                                              * Afstand van de oneven inspringende tiles => (Mathf.Sqrt(3) / 2)
                                                                                                                              * 
                                                                                                                              * (scaleWorldPosition.x - (Mathf.Abs(r % 2) * (Mathf.Sqrt(3) / 2)))
                                                                                                                              * ^ dit is de echte positie van uw tile, 
                                                                                                                              * 
                                                                                                                              * Uiteindelijk delen we nog eens alles door sqrt(3) wat de breedte is van een tile
                                                                                                                              */
            //Calculation of the colum cordinat
            int q = colom - (r - (r&1)) / 2; //what does the & operator do?
            int s = -q-r; //do we still need this tho?
                
            return new GridPosition(r, q, s);
        }

        public static Vector3 GridPositionToWorld(GridPosition gridposition)
        {
            //TODO: Convert GridPosition to Inworld position!

            //colom again wtf does this mf do???
            float colom = gridposition.Q + (gridposition.R - (gridposition.R&1)) / 2;// Again with the & operator wtf DOES IT DO?

            float x = colom * Mathf.Sqrt(3) + ((Mathf.Abs(gridposition.R % 2) * (Mathf.Sqrt(3) / 2)));
            float y = gridposition.R / 0.65f; //the 0.65f is defenatly a scaling factor, what would else be?

            return new Vector3(x, 0, y);
        }
    }
}


