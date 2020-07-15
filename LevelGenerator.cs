using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //variables
    [SerializeField] private GameObject _levelPlatformPrefab;
    [SerializeField] private int _levelLength; //amount of platforms in our level
    [SerializeField] private int _startPlatformLength = 5, _endPlatformLength = 5;
    [SerializeField] private int _distanceBetweenPlatforms;
    [SerializeField] private Transform _platformPrefab, _platformParent;
    [SerializeField] private Transform _monsterPrefab, _monsterParent;
    [SerializeField] private Transform _healthCollectablePrefab, _healthCollectableParent;
    [SerializeField] private float _platformPosition_minY = 0f, _platformPosition_maxY = 10f;
    [SerializeField] private int _platformLength_Min = 1, _platformLength_Max = 4;
    [SerializeField] private float _chance_For_Monster_Existence = 0.25f, _chance_For_Collectible_Existence = 0.1f;
    [SerializeField] private float _healthCollectible_MinY = 1f, _healthCollectible_MaxY = 3f;
    private float _platformLastPositionX;

    //determines which platform is going to have a collectible or monster, of if the platform is not going to have any of those.
    private enum PlatformType
    {
        None,
        Flat
    }
    //information for our platform position. an inner class
    private class PlatformPositionInfo
    {
        public PlatformType platformType;
        public float positionY;
        public bool hasMonster;
        public bool hasCollectable;

        //constructor
        public PlatformPositionInfo(PlatformType type, float posY, bool has_Monster, bool has_Collectable)
        {
            platformType = type;
            positionY = posY;
            hasMonster = has_Monster;
            hasCollectable = has_Collectable;

        }              


    } //class PlatformPositionInfo

    private void Start()
    {
        
        GenerateLevel();
    }

    //gets the required information in order to create the platforms
    private void FillOutPositionInfo(PlatformPositionInfo[] info)
    {
        int currentPlatformIndex = 0;
        for(int i = 0; i < _startPlatformLength; i++)
        {
            info[currentPlatformIndex].platformType = PlatformType.Flat;
            info[currentPlatformIndex].positionY = 0f;
            //increment platform index
            currentPlatformIndex = currentPlatformIndex + 1;
        }

        //looping through every platform
        while(currentPlatformIndex < _levelLength - _endPlatformLength)
        {
            if(info[currentPlatformIndex - 1].platformType != PlatformType.None)
            {
                currentPlatformIndex = currentPlatformIndex + 1;
                continue;
            }

            float platformPositionY = Random.Range(_platformPosition_minY, _platformPosition_maxY); //y position of our platform
            int platformLength = Random.Range(_platformLength_Min = 1, _platformLength_Max);

            for(int i = 0; i < platformLength; i = i + 1)
            {
                bool has_Monster = Random.Range(0f, 1f) < _chance_For_Monster_Existence;
                bool has_Collectable = Random.Range(0f, 1f) < _chance_For_Collectible_Existence;

                info[currentPlatformIndex].platformType = PlatformType.Flat;
                info[currentPlatformIndex].positionY = platformPositionY;
                info[currentPlatformIndex].hasMonster = has_Monster;
                info[currentPlatformIndex].hasCollectable = has_Collectable;

                currentPlatformIndex = currentPlatformIndex + 1;

                if(currentPlatformIndex > _levelLength - _endPlatformLength)
                {
                    currentPlatformIndex = _levelLength - _endPlatformLength;
                    break;
                }

            }

            for(int i = 0; i < _endPlatformLength; i = i + 1)
            {
                info[currentPlatformIndex].platformType = PlatformType.Flat;
                info[currentPlatformIndex].positionY = 0f;
                currentPlatformIndex = currentPlatformIndex + 1;

            }


        }

        


    }
    //creates the platforms
    private void CreatePlatforms(PlatformPositionInfo[] info)
    {
        for(int i = 0; i < info.Length; i = i + 1)
        {
            PlatformPositionInfo positionInfo = info[i];
            {
                if(positionInfo.platformType == PlatformType.None)
                {
                    continue;
                }
            }

            Vector3 platformPosition;
            //we are going to check if the game is started or not

            platformPosition = new Vector3(_distanceBetweenPlatforms * i, positionInfo.positionY, 0);

            //save the plaform position x for later use

            Transform createBlock = (Transform)Instantiate(_platformPrefab, platformPosition, Quaternion.identity);
            createBlock.parent = _platformParent;

            if(positionInfo.hasMonster)
            {
                //code later
            }
            if(positionInfo.hasCollectable)
            {
                //code later
            }


        }
    }

    public void GenerateLevel()
    {
        PlatformPositionInfo[] plaformInfo = new PlatformPositionInfo[_levelLength];

        for(int i = 0; i < plaformInfo.Length; i = i + 1)
        {
            plaformInfo[i] = new PlatformPositionInfo(PlatformType.None, -1f, false, false);
        }
        FillOutPositionInfo(plaformInfo);
        CreatePlatforms(plaformInfo);
    }
   





} //class LevelGenerator
