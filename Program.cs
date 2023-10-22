using System;
using System.Collections.Generic;

class Food
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }

    public Food(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}

class Buffet
{
    public List<Food> Menu;

    public Buffet()
    {
        Menu = new List<Food>
        {
            new Food("Sushi", 300, true, false),
            new Food("Pizza", 450, true, false),
            new Food("Salad", 200, false, false),
            new Food("Ice Cream", 250, false, true),
            new Food("Burger", 600, true, false),
            new Food("Fruit Salad", 120, false, true),
            new Food("Spicy Wings", 350, true, false),
        };
    }

    public Food Serve()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, Menu.Count);
        return Menu[randomIndex];
    }
}

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory { get; private set; }

    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    public bool IsFull => calorieIntake > 1200;

    public void Eat(Food item)
    {
        if (!IsFull)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"El Ninja está comiendo {item.Name}. Picante: {item.IsSpicy}, Dulce: {item.IsSweet}");
        }
        else
        {
            Console.WriteLine("El Ninja está lleno y no puede comer más.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Buffet buffet = new Buffet();
        Ninja ninja = new Ninja();

        while (!ninja.IsFull)
        {
            Food food = buffet.Serve();
            ninja.Eat(food);
        }

        Console.WriteLine("El Ninja está lleno y no puede comer más.");
    }
}
