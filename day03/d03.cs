// Advent of Code 2016 - Day03 - solution
using System;
using System.IO;
using System.Linq;


public class ADOC2016_day01{
    static public void Main (){ 
        String[] inputLines;
        try {
            String filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                              +Path.DirectorySeparatorChar + "input.txt";
            inputLines = System.IO.File.ReadAllLines(filepath);
            Console.WriteLine("Part1: "+Day03Task1(inputLines) + " Part2: "+Day03Task2(inputLines));
        }
        catch(Exception e) {   
            Console.WriteLine(">EX: "+e.Message);    
        }    

        Console.ReadKey();
    }

    static public int Day03Task1(String[] lines){ 
        int val = 0;
        foreach (var line in lines){
            int[] nums = new int[3]; int ptr = 0, sum = 0;
            String[] words = (line.Trim()).Split(' ');
            foreach (var ch in words)   {
                if(ch.Length>0) if(ch[0]!=' '){
                    nums[ptr]=Convert.ToInt16(ch);
                    sum+=nums[ptr]; ptr++;
                }                
            } if(sum-2*nums.Max()>0)val++;
        } return val;
    }

    static public int Day03Task2(String[] lines){ 
        int val = 0, tri = 0, side = 0;
        int[,] nums = new int[3,3];
        foreach (var line in lines){
            String[] words = (line.Trim()).Split(' ');
            foreach (var ch in words)   {
                if(ch.Length>0) if(ch[0]!=' '){
                    nums[tri,side]=Convert.ToInt16(ch);
                    tri++;
                }              
            } side++;
            if (side>2){
                for(int i=0;i<3;i++){
                  var sum = nums[i,0]+nums[i,1]+nums[i,2]; 
                  var max = Math.Max(nums[i,0], Math.Max(nums[i,1], nums[i,2])); 
                  if(sum-2*max>0)val++;
                  Console.WriteLine(nums[i,0]+","+nums[i,1]+","+nums[i,2]);
                }
                side=0;
            } tri = 0; 
        } return val;
    }
}
