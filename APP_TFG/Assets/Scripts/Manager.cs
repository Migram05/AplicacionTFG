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

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }

    //Information to save
    string [] appData = new string[3];
    private string todayGoodThings;
    private string todayBadThings;

    private string saveDataPath = "APP_SavedData/dataAPP.txt";

    struct scheduleInformation
    {
        string actividad;
        string emocion;
    }
    struct dayInformation
    {
        Vector<scheduleInformation> scheduleVector;
        string goodText;
        string badText;
    }

    private int[] dayVectorIndex = new int[31];
    private Vector<dayInformation> dayInformationVector;
    public void setTodayGoodThings(string tGT) { todayGoodThings = tGT; }
    public void setTodayBadthings(string tBT) { todayGoodThings = tBT; }

    private void saveInformation() 
    {
        appData[0] = username;
        appData[1] = getCurrentMonth();
        appData[2] = getCurrentYearString();
        File.WriteAllLines(saveDataPath, appData);
    }

    private void loadInformation()
    {

    }

    private void OnApplicationQuit()
    {
        saveInformation();
    }
    //

    private DateTime dateTime;
    public bool hasUser { get; private set; }
    private string numberToMonthName(int n) { switch (n) { case 1: return "Enero"; case 2: return "Febrero"; case 3: return "Marzo"; case 4: return "Abril"; case 5: return "Mayo"; case 6: return "Junio"; case 7: return "Julio"; case 8: return "Agosto"; case 9: return "Septiembre"; case 10: return "Octubre"; case 11: return "Noviembre"; case 12: return "Diciembre"; default: return "MesDesconocido"; } }

    private string numberToDayName(int n) { switch (n) { case 1: return "Lunes"; case 2: return "Martes"; case 3: return "Miércoles"; case 4: return "Jueves"; case 5: return "Viernes"; case 6: return "Sábado"; case 0: return "Domingo"; default: return "DiaDesconocido"; } }
    
    private int currentMonth;
    public string getCurrentMonth() { return numberToMonthName(currentMonth); }

    private int currentYear;
    public string getCurrentYearString() { return currentYear.ToString(); }

    public int getCurrentYear() { return currentYear; }

    private int numDaysInMonth;
    public int getNumDaysInMonth() { return numDaysInMonth; }

    private int currentDay;
    public int getCurrentDay() { return currentDay; }

    public string getCurrentDayName() { return numberToDayName((int)System.DateTime.Today.DayOfWeek); }

    public int getFirstDay() {
        DayOfWeek primerDia = dateTime.DayOfWeek;
        int result = (int)primerDia;
        if (result == 0) result = 7; //Ajustamos el valor para que si es 0 es decir, domingo, sea considerado el séptimo día en realidad
        return result;
    }
    

    private string username;
    public void setUserName(string newName) 
    { 
        username = newName;
        StartCoroutine(LoadSceneDelayed(2, 1));
    }
    public IEnumerator LoadSceneDelayed(float time, int sceneNum)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneNum);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        for (int e = 0; e < dayVectorIndex.Length; e++) dayVectorIndex[e] = -1;

        hasUser = File.Exists(saveDataPath);
        if (hasUser)
        {
            loadInformation();
            StartCoroutine(LoadSceneDelayed(0, 1)); //Si el usuario ya está registrado, carga la escena
        }
        else File.Create(saveDataPath);
        // Crea un objeto DateTime para el primer día del mes.
        dateTime = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
        currentDay = System.DateTime.Today.Day;
        currentMonth = System.DateTime.Today.Month;
        currentYear = System.DateTime.Today.Year;
        numDaysInMonth = System.DateTime.DaysInMonth(currentYear, currentMonth);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
