using SingletonPatternExample;



//The Client Code for Naive Singleton
Singleton s1 = Singleton.GetInstance();
Singleton s2 = Singleton.GetInstance();

Console.WriteLine($@"Instances of {nameof(s1)} and {nameof(s2)} are: {(s1 == s2 ? true : false)}");


//The Client Code for Multi-Threaded Singleton
Console.WriteLine(
    "{0}\n{1}\n\n{2}\n",
    "If you see the same value, then singleton was reused (yay!)",
    "If you see different values, then 2 singletons were created (booo!!)",
    "RESULT:"
);

Thread process1 = new Thread(() => 
{
    TestSingleton("John");
});

Thread process2 = new Thread(() => 
{
    TestSingleton("Doe");
});

process1.Start();
process2.Start();

process1.Join();
process2.Join();



static void TestSingleton(string value)
{
    SingletonThreaded st = SingletonThreaded.GetInstance(value);
    Console.WriteLine(st.Value);
}