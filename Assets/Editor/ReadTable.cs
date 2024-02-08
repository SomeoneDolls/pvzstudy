using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Startup
{
    static Startup()
    {
        string path = Application.dataPath + "/Editor/关卡管理.xlsx";
        string assName = "TableData/Level";
        FileInfo fileInfo = new FileInfo(path);
        LevelData levelData = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo)) 
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["僵尸"];
            for(int i = worksheet.Dimension.Start.Row+2;i<= worksheet.Dimension.End.Row; i++)
            {
                
                LevelItem levelItem = new LevelItem();
                Type type = typeof(LevelItem);
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    //Debug.Log("��������" + worksheet.GetValue(2, j).ToString());
                    FieldInfo variable = type.GetField(worksheet.GetValue(2, j).ToString());
                    //Debug.Log("���ݣ�"+variable);
                    string tableValue = worksheet.GetValue(i, j).ToString();
                    variable.SetValue(levelItem, Convert.ChangeType(tableValue, variable.FieldType));
                }
                levelData.LevelDataList.Add(levelItem);
            } 
        }
        AssetDatabase.CreateAsset(levelData, "Assets/Resources/" + assName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}