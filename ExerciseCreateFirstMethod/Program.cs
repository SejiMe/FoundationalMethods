void DisplayRandomNumbers(){
    Random random = new();

    for(int i = 0; i < 10; i++) {
        Console.Write($"{random.Next(1, 100)} ");
    }

    Console.WriteLine();
};

DisplayRandomNumbers();