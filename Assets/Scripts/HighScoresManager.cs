using System.Collections.Generic;
using System.IO;

public static class HighScoresManager
{
    public static List<int> highScores = new List<int>(); // List to hold the high scores

    // Merge sort algorithm implementation
    public static List<int> MergeSort(List<int> originalList)
    {
        if (originalList.Count <= 1)
        {
            return originalList;
        }

        int middleOfList = originalList.Count / 2;
        List<int> leftSide = originalList.GetRange(0, middleOfList);
        List<int> rightSide = originalList.GetRange(middleOfList, originalList.Count - middleOfList);

        leftSide = MergeSort(leftSide);
        rightSide = MergeSort(rightSide);

        return Merge(leftSide, rightSide);
    }

    // Helper function to merge two sorted lists into one sorted list
    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> sortedList = new List<int>();
        int leftIndex = 0, rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            sortedList.Add(left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++]);
        }

        sortedList.AddRange(left.GetRange(leftIndex, left.Count - leftIndex));
        sortedList.AddRange(right.GetRange(rightIndex, right.Count - rightIndex));

        return sortedList;
    }

    // Load the high scores from the text file
    public static void LoadHighScores()
    {
        string path = "highscores.txt"; // Path to the text file holding the high scores

        // Create the file if it doesn't exist
        if (!File.Exists(path))
        {
            using (FileStream fs = File.Create(path))
            {
                fs.Close();
            }
        }

        // Read the scores from the text file and add them to the list of high scores
        using (StreamReader reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                int highScore = int.Parse(line);
                highScores.Add(highScore);
            }
        }
    }

    // Save the high scores to the text file
    public static void SaveHighScores(List<int> highScores)
    {
        string path = "highscores.txt"; // Path to the text file holding the high scores

        // Write the high scores to the text file
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (int highScore in highScores)
            {
                writer.WriteLine(highScore);
            }
        }
    }

    // Update the high scores list with a new score, sort it, and trim it to keep only the top 5 scores
    public static void UpdateHighScores(int newHighScore)
    {
        highScores = new List<int>(); // Clear the existing high scores list
        LoadHighScores(); // Load the high scores from the text file
        highScores.Add(newHighScore); // Add the new high score to the list
        highScores = MergeSort(highScores); // Sort the list using the merge sort algorithm
        if (highScores.Count > 5) // Trim the list to keep only the top 5 scores
        {
            highScores.RemoveAt(0);
        }
        SaveHighScores(highScores); // Save the updated high scores to the text file
    }
}
