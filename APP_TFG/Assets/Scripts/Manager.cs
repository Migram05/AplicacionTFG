using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }

    //Information to save
    private string todayGoodThings;
    private string todayBadThings;
    private List<string> activitiesList =  new List<string>();
    private List<string> emotionsList = new List<string>();

    private string saveDataPath = "APP_SavedData/dataAPP.txt";
     struct dayInformation
    {
        public bool usable;
        public string[] actividades;
        public string[] emociones;
        public string goodText;
        public string badText;
    }

    private List<dayInformation> dayInformationList = new List<dayInformation>(31);
    public void setTodayGoodThings(string tGT) { todayGoodThings = tGT; }
    public void setTodayBadthings(string tBT) { todayBadThings = tBT; }

    public void saveActivity(string name) { activitiesList.Add(name); }

    public void saveEmotion(string name) { emotionsList.Add(name); }

    public string getSavedGoodText() { return dayInformationList[selectedDay - 1].goodText; }

    public string getSavedBadText() { return dayInformationList[selectedDay - 1].badText; }

    public string[] getSavedActivities() { return dayInformationList[selectedDay-1].actividades; }

    public string[] getSavedEmotions() { return dayInformationList[selectedDay - 1].emociones; }

    private void saveTodayInformation() //Guarda la informaci�n del d�a de hoy en la lista de de dias
    {
        dayInformation info = new dayInformation();
        info.usable = true;
        info.actividades = activitiesList.ToArray();
        info.emociones = emotionsList.ToArray();
        info.goodText = todayGoodThings;
        info.badText = todayBadThings;
        dayInformationList[getCurrentDay() - 1] = info;
    }
    private void saveInformation() //Escribe la informaci�n guardada en el archivo de guardado
    {
        StreamWriter writer = new StreamWriter(saveDataPath);
        writer.WriteLine(username);
        writer.WriteLine(getCurrentMonth());
        writer.WriteLine(getCurrentYearString());
        int dayNum = 1;
        foreach(dayInformation day in dayInformationList)
        {
            if(day.usable)
            {
                writer.WriteLine(dayNum);
                dayInformation info = day;
                string todayActivities = "";
                for (int x = 0; x < info.actividades.Length; x++)
                {
                    todayActivities += info.actividades[x] + " ";
                }
                writer.WriteLine(todayActivities);
                string todayEmotions = "";
                for (int x = 0; x < info.emociones.Length; x++)
                {
                    todayEmotions += info.emociones[x] + " ";
                }
                writer.WriteLine(todayEmotions);
                writer.WriteLine(info.goodText);
                writer.WriteLine(info.badText);
            }
            dayNum++;
        }
        writer.Close();
    }
    private string lastSavedMonth;
    private string lastSavedYear;
    private void loadInformation() //Carga la informaci�n guardada
    {
        StreamReader reader = new StreamReader(saveDataPath);
        username = reader.ReadLine();
        lastSavedMonth = reader.ReadLine();
        lastSavedYear = reader.ReadLine();
        if (lastSavedMonth == getCurrentMonth() && lastSavedYear == getCurrentYearString()) //Si el mes y a�o de �ltimo guardado y el actual son los mismos se carga la informaci�n
        {
            string readString = reader.ReadLine();
            while (readString != null)
            {
                int dayNum = 0;
                if (Int32.TryParse(readString, out dayNum))
                {
                    //Se ha le�do correctamente el d�a
                    string lineRead = reader.ReadLine();
                    string[] activities = lineRead.Split(' ');
                    lineRead = reader.ReadLine();
                    string[] emotions = lineRead.Split(' ');
                    dayInformation info = new dayInformation();
                    info.usable = true;
                    info.actividades = activities;
                    info.emociones = emotions;
                    info.goodText = reader.ReadLine();
                    info.badText = reader.ReadLine();
                    dayInformationList[dayNum-1] = info;
                }
                readString = reader.ReadLine();
            }
        }
        else
        {
            //TO DO
            //Borrar datos de guardado y mostrar resumen del mes
        }
        reader.Close();
    }

    private void OnApplicationQuit()
    {
        saveInformation();
    }
    //

    private DateTime dateTime;
    public bool hasUser { get; private set; }
    private string numberToMonthName(int n) { switch (n) { case 1: return "Enero"; case 2: return "Febrero"; case 3: return "Marzo"; case 4: return "Abril"; case 5: return "Mayo"; case 6: return "Junio"; case 7: return "Julio"; case 8: return "Agosto"; case 9: return "Septiembre"; case 10: return "Octubre"; case 11: return "Noviembre"; case 12: return "Diciembre"; default: return "MesDesconocido"; } }

    private string numberToDayName(int n) { switch (n) { case 1: return "Lunes"; case 2: return "Martes"; case 3: return "Mi�rcoles"; case 4: return "Jueves"; case 5: return "Viernes"; case 6: return "S�bado"; case 0: return "Domingo"; default: return "DiaDesconocido"; } }
    
    private int currentMonth;
    public string getCurrentMonth() { return numberToMonthName(currentMonth); }

    private int currentYear;
    public string getCurrentYearString() { return currentYear.ToString(); }

    public int getCurrentYear() { return currentYear; }

    private int numDaysInMonth;
    public int getNumDaysInMonth() { return numDaysInMonth; }

    private int currentDay;
    public int getCurrentDay() { return currentDay; }

    private int selectedDay;

    public int getSelectedDay() { return selectedDay;}

    public string getCurrentDayName() { return numberToDayName((int)System.DateTime.Today.DayOfWeek); }

    public bool canInteractWithButton(int day) //M�todo que determina si se puede hacer click en un bot�n o no
    {
        return (day == currentDay || dayInformationList[day-1].usable == true);
    }

    public int getFirstDay() {
        DayOfWeek primerDia = dateTime.DayOfWeek;
        int result = (int)primerDia;
        if (result == 0) result = 7; //Ajustamos el valor para que si es 0 es decir, domingo, sea considerado el s�ptimo d�a en realidad
        return result;
    }

    private string username = "";
    public string getUsername() { return username; }
    public void setUserName(string newName) 
    {
        Debug.Log(newName);
        username = newName;
        StartCoroutine(LoadSceneDelayed(2, 1));
    }
    public IEnumerator LoadSceneDelayed(float time, int sceneNum)
    {
        yield return new WaitForSeconds(time);
        //TEST
        if(sceneNum == 6)
        {
            saveTodayInformation();
            Debug.Log("Borrar lineas de prueba en el manager");
        }
        //
        SceneManager.LoadScene(sceneNum);
    }

    public void callendarButtonClicked(int num)
    {
        selectedDay = num;
        if(num == currentDay) //Si el dia seleccionado es el actual, se activa la escena diaria
        {
            StartCoroutine(LoadSceneDelayed(0, 3));
        }
        else //Sino, se muestra un resumen del d�a
        {
            StartCoroutine(LoadSceneDelayed(0, 2));
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        for(int i = 0; i < dayInformationList.Capacity; ++i) //Inicializaci�n de la lista
        {
            dayInformation info = new dayInformation();
            info.usable = false;
            dayInformationList.Add(info);
        }
        // Crea un objeto DateTime para el primer d�a del mes.
        dateTime = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
        currentDay = System.DateTime.Today.Day;
        currentMonth = System.DateTime.Today.Month;
        currentYear = System.DateTime.Today.Year;
        numDaysInMonth = System.DateTime.DaysInMonth(currentYear, currentMonth);

        hasUser = File.Exists(saveDataPath);
        if (hasUser)
        {
            loadInformation();
            StartCoroutine(LoadSceneDelayed(0, 1)); //Si el usuario ya est� registrado, carga la escena
        }
        else File.Create(saveDataPath);
    }
}
