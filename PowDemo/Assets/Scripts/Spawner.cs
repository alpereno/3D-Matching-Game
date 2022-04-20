using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private Stuff[] stuffs;
    [SerializeField] private Transform cubePrefab;
    [SerializeField] private Thing[] things;
    Vector3[] availablePoss;
    bool keepSpawn;
    int thingIndex;                         // things arrayindeki ilerlemeyi kayıtlı tutmak için
    int stuffCount;
    int stuffFactor;
    int remainingStuffNumber;

    private void Start()
    {
        keepSpawn = true;
        availablePoss = new Vector3[64];
        fillArray();
        //printArray();
        shuffleArray();
        //printArray();

        createObject();
    }
                            // yorum satırları proje sonunda ingilizceye çevrilip, yeniden düzenlenecektir.

    // 4x4x4 şeklinde belirli prefablardan (avakado, zil, kitap şişe vs) küp oluşturuyor, bu prefabların sayısı random olarak
    // oluşuyor (istenilirse classlardan "piece" sayısı aktif edilip aşağıdaki bazı yorum satırları açılabilir)
    // oluşan random sayısı 63ü geçmeyecek şekilde ve ve son oluşacak prefabın sayısı random sayı ile eksik çıkarsa
    // 63 e tamamlayacak şekilde yeniden düzenleniyor.
    // ileride farklı işlemler yapılacağından referans tutabilmesi için base class şeklinde instantiate edilmiştir.
    // pozisyonlarının random olması için fisher yates algoritmasını baz alıp, onu da uyarladım.

    void createObject()
    {
        //for (int i = 0; i < 64; i++)
        //{
        //    //Transform cubeObject = Instantiate(cubePrefab, availablePoss[i], Quaternion.identity);
        //    //cubeObject.transform.parent = transform;
        //}
        remainingStuffNumber = 63;
        int index = 0;  // aynı yerde oluşmasın diye avacado carrot falan her forda 0 dan başlasaydı değer shuffle arayında
                        // hep 0 dan başlayarak kaç tane varsa o kadar ilerliyordu yani birbirlerinin üzerlerine oluşturuluyordu

        while (keepSpawn)
        {
            stuffFactor = (int)(Random.Range(0, 6));    // son eleman hariç en fazla bir elemandan 18 tane olsun istedim
            //print("init "+ remainingStuffNumber);

            // eğer son elemandaysak veya oluşacak eleman sayısı ile oluşan eleman sayısı toplamı kalan elemanlardan fazlaysa
            // oluşacak eleman sayısı yeniden düzenlenmeli
            // son eleman olup eksik oluşacak çıkarsa tam 63 olacak şekilde, oluşacak sayı oluşan ile toplandığında 63den fazlaysa
            // tam 63 olacak şekilde düzenlenmeli
            print("stuff factor *3 = " + stuffFactor * 3);
            if (thingIndex == things.Length - 1 || stuffFactor * 3 > remainingStuffNumber)
            {
                stuffFactor = remainingStuffNumber / 3;
            }
            stuffCount = stuffFactor * 3;
            print("esas stuff factor * 3 = " + stuffFactor * 3);
            for (int i = 0; i < stuffCount; i++)
            {
                Thing spawnedObject = Instantiate(things[thingIndex], availablePoss[index], Quaternion.identity);
                spawnedObject.transform.parent = transform;
                remainingStuffNumber--;
                //print(remainingStuffNumber);
                index++;
            }

            //for (int i = 0; i < things[thingIndex].piece; i++)
            //{
            //    Thing spawnedObject = Instantiate(things[thingIndex], availablePoss[index], Quaternion.identity);
            //    spawnedObject.transform.parent = transform;
            //    remainingStuffNumber--;
            //    index++;
            //}
            if (thingIndex == things.Length - 1)
            {
                keepSpawn = false;
            }
            thingIndex++;
        }
    }

    // shuffles array
    void shuffleArray() {
        int lastIndex;
        lastIndex = availablePoss.Length - 1;
        while (lastIndex > 0)
        {
            int randomIndex = Random.Range(0, lastIndex);
            Vector3 temp = availablePoss[lastIndex];
            availablePoss[lastIndex] = availablePoss[randomIndex];
            availablePoss[randomIndex] = temp;
            lastIndex--;
        }
    }

    // fills the elements of the array in a sequential manner
    void fillArray() {
        int index = 0;
        for (float x = -1.5f; x < 2; x++)
        {
            for (float y = -1.5f; y < 2; y++)
            {
                for (float z = -1.5f; z < 2; z++)
                {
                    availablePoss[index] = new Vector3(x, y, z);
                    index++;
                }
            }
        }
    }
    
    // for print the array
    void printArray() {
        int index = 0;
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    print(availablePoss[index]);
                    index++;
                }
            }
        }
    }
}
