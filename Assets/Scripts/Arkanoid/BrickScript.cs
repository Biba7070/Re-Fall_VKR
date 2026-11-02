using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{

    public int points;               //Выдаваемое кол-во чоков при контакте с объектом
    public int hitsToBreak;          //Количество ударов для ломания объекта
    public bool isBrickBroken;       

   /* private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerForArkanoid>();
    }*/
    //Добавить для объектов, на которые нужно 2 удара, сметинь материал при попадании public 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBrickBroken == true) //Если в объект попали, и переменная hitsToBreak стала равна 0, то проигрывается анимация исчезновения объекта
        {
            this.gameObject.SetActive(false);
        }
    }
    public void BreakBrick()
    {
        hitsToBreak--; //Когда мяч попадает по объекту, у hitsToBreak значение уменьшается на 1
      //  audioManager.PlaySFX(audioManager.hitBrickOriginal);
    }
}
