﻿namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        bool retakeQuiz = true;

        while (retakeQuiz)
        {

            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }

            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");

            Console.WriteLine("Do you want to retake the quiz? (y/n)");
            string response = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(response))
            {
                retakeQuiz = false;
                break;
            }

            while (response != "y" && response != "n")
            {
                Console.WriteLine("Invalid input, please enter 'y' or 'n'.");
                response = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(response))
                {
                    retakeQuiz = false;
                    break;
                }
            }

            retakeQuiz = response == "y";

        }
    }

    public static string GetPercentCorrect(float numberCorrectAnswers, float numberOfQuestions)
    {
        return (numberCorrectAnswers / numberOfQuestions * 100) + "%";
    }

    public static bool AskQuestion(Question question)
    {
        DisplayQuestion(question);

        string userGuess = GetGuessFromUser();
        return DisplayResult(userGuess, question);
    }

    public static string GetGuessFromUser()
    {
        return Console.ReadLine();
    }

    public static bool DisplayResult(string userGuess, Question question)
    {
        if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct");
            return true;
        }

        Console.WriteLine("Incorrect");
        return false;
    }

    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine("Question: " + question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + question.Answers[i]);
        }
    }

    public static string GetFilePath()
    {
        return "Trivia.txt";
    }

    public static Question[] LoadQuestions(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        Question[] questions = new Question[lines.Length / 5];
        for (int i = 0; i < questions.Length; i++)
        {
            int lineIndex = i * 5;
            string questionText = lines[lineIndex];

            string answer1 = lines[lineIndex + 1];
            string answer2 = lines[lineIndex + 2];
            string answer3 = lines[lineIndex + 3];

            string correctAnswerIndex = lines[lineIndex + 4];

            Question question = new();
            question.Text = questionText;
            question.Answers = new string[3];
            question.Answers[0] = answer1;
            question.Answers[1] = answer2;
            question.Answers[2] = answer3;
            question.CorrectAnswerIndex = correctAnswerIndex;
            questions[i] = question;
        }
        return questions;
    }
}
