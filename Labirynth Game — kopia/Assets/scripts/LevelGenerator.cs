﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLabirynth()
    {
        for(int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x,z);
            }
        }

    }


    void GenerateTile(int x, int z)
{
	//Pobieramy kolor pixela w pozycji x i y
	Color pixelColor = map.GetPixel(x, z);
	//Jeżeli alpha koloru jest równa 0, czyli kolor jest w pełni przezroczysty to pomijamy pixel
	if(pixelColor.a == 0)
	{
		return;
	}
    pixelColor.a = 0f;

        //Przeszukujemy po wszystkich kolorach w naszej tablicy
	foreach(ColorToPrefab colorMapping in colorMappings)
	{
        //Jeżeli któryś z kolorów w naszej tablicy odpowiada to ustaw prefab
		if(colorMapping.color.Equals(pixelColor))
		{
                //wylicz pozycje na podstawie współrzędnych pixela
			Vector3 position = new Vector3(x, 0, z) * offset;
                //Utwórz wybrany obiekt w wybranej pozycji
                	Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            	}
}

}}
