using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // on fait une reference au slider dans unity 

    public Gradient gradient; // ref au gradient editor dans unity -> dégradé de couleur
    public Image fill; // ref au fill de la jauge de vie

    // cette methode elle sera appeller a l'initialisation ou la re initialisation des points de vie du joueur
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; // on remplis le slider au max de pts de vie donc 100/100
        slider.value = health; // le jeu demarre avec le joueur a 100% de ses points de vie

        fill.color = gradient.Evaluate(1f);  //la couleur du remplissage va être = au gradient 1f-> 100% du gradient tt a droite du gradient editor 
    }

    // indiquer à la barre de vie quel est le nbr de pts de vie à afficher
    // methode a appeller quand le joueur va prendre des dégats ou quand il va être soigner
    public void SetHealth(int health) 
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue);//même principe qu'a la ligne 18 le seul changement est le normalized value car le graident editor n'accepte que des valeurs entre 0 et 1 on "force" le système a donner des valeurs entre 0 et 1 et non en % comme dans value
    }


}
