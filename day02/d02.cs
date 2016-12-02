// Advent of Code 2016 - Day02 - solution
using System;
using System.IO;
using System.Collections.Generic;


public class ADOC2016_day01{
    static public void Main (){ 
        String[] inputLines;
        try {
            String filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                              +Path.DirectorySeparatorChar + "input.txt";
            inputLines = System.IO.File.ReadAllLines(filepath);
            Console.WriteLine("Part1: "+Day02Task1(inputLines)+" Part2: "+Day02Task2(inputLines));
        }
        catch(Exception e) {   
            Console.WriteLine(">EX: "+e.Message);    
        }    

        Console.ReadKey();
    }

    static public String Day02Task1(String[] lines){ 
        String pin = "";
        int val = 5;
        foreach (var line in lines){
            foreach (var ch in line){
                switch (ch){
                    case 'U': if(val-3>0)val-=3; break;
                    case 'D': if(val+3<10)val+=3;break;
                    case 'L': if(val%3!=1)val--;break;
                    case 'R': if(val%3!=0)val++;break;
                }
            }
            pin += Convert.ToString(val);
        }
        return pin;
    }

    static public String Day02Task2(String[] lines){ 
        int[,] nums = new int[5, 5] {{0,0,1,0,0},{0,2,3,4,0},{5,6,7,8,9},{0,10,11,12,0},{0,0,13,0,0}} ;
        String pin = ""; int pos=2;
        foreach (var line in lines){
            foreach (var ch in line){
                int inc = pos + ((ch!='U')?((ch!='D')?((ch!='L')?((ch!='R')?0:+1):-1):+10):-10);
                if((inc>=0) && (inc<45) && ((inc%10)<5))
                    if(nums[(inc-inc%10)/10,inc%10]!=0)
                        pos=inc;
            }
            int val = nums[(pos-pos%10)/10,pos%10];
            if(val<10) pin +=Convert.ToString(val);
                else pin+=(char)('A'+val-10);
        }
        return pin;
    }
}
