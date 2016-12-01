// Advent of Code 2016 - Day01 - solution
using System;
using System.IO;
using System.Collections.Generic;


public class ADOC2016_day01{
    static public void Main (){ 
        String input = "";
        String filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        filepath += Path.DirectorySeparatorChar + "input.txt";
        try {
            StreamReader sr = new StreamReader(filepath);
            input = sr.ReadToEnd(); 
            sr.Close();
        }
        catch(Exception e) {   
            Console.WriteLine(">EX: "+e.Message);    
        }    

        Console.WriteLine(">Easter Bunny Headquarters found "+Convert.ToString(Day01(input))+" blocks away!");
        Console.ReadKey();
    }

    static public int Day01(String inputStr){ 
        int X = 0, Y = 0, dir = 0, val;
        List<string> visited = new List<string>();
        visited.Add("["+Convert.ToString((X))+","+Convert.ToString((Y))+"]"); // in case 0,0 is the answer
        char rot;

        String[] explode = (System.Text.RegularExpressions.Regex.Replace(inputStr, @"\s+", "")).Split(',');
        foreach (var item in explode){
            rot = item[0]; val=Int32.Parse(item.Substring(1));
            dir += ((rot-76>0)?1:-1);
            if(dir<0) dir = 3; 
                else if (dir>3) dir = 0; 
                           
            for (int i = 0;i<val;i++){   
                if(dir%2!=1) Y+= ((dir>1)?-1:1);
                    else X+= ((dir>1)?-1:1);
                string current = "["+Convert.ToString((X))+","+Convert.ToString((Y))+"]";
                if(visited.Contains(current))
                    return Math.Abs(X)+Math.Abs(Y); // part B, segments intersection
                visited.Add(current);
            }     
        }
        return Math.Abs(X)+Math.Abs(Y); //part A, path destination distance
    }
}
