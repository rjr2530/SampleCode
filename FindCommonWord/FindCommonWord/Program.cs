using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FindCommonWord
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\raifo_000\Desktop\macbeth.txt"); //opens file macbeth.txt and reach each line
            
            char[] delimiters = new char[] { ',', '.', '?', ':', ';', '!', ' ','\'','-'}; //array of delimiters to split a line into words
            
            string[] words; //array to store the words in each line
            
            Dictionary<string,int> wordCounts = new Dictionary<string,int>(); //dictionary to hold each word and the numer of appearences in the file

            //loops through each line and splits the line into only words
            foreach (string line in lines)
            {
                words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                
                //loops through each word in the line and adds it to the dictionary and its number of appearances in the file
                foreach(string word in words)
                {
                    if (word.Length > 4 && word.ToUpper() != "MACBETH") //checks if word has more than 4 characters and coverts word to uppercase to captuer lowercase and uppercase of word
                    {                        
                        if (wordCounts.ContainsKey(word.ToUpper())) //if word is already in dictionary add 1 to its current number of appearances
                        {
                            wordCounts[word.ToUpper()] = wordCounts[word.ToUpper()]+=1;
                        }
                        else //if word is not already in the dictionary add the word and 1 for its number of appearances
                        {
                            wordCounts.Add(word.ToUpper(), 1); 
                        }
                    }
                }
            }

            //loops through each entry in the dicitonary and finds the entry with the most appearances
            foreach(var item in wordCounts)
            {
                if(item.Value == wordCounts.Values.Max()) //compares the value of each entry to the max value in the dictionary
                Console.WriteLine("\"{0}\" is the second most common word in Macbeth with {1} occurences.", item.Key,item.Value); //display the word with the most appearances and its number of appearances
            }

            Console.ReadLine();
        }
    }
}
