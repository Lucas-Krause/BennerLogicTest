using BennerLogicTest.Classes;

Network network = new(8);

network.Connect(1, 6);
network.Connect(6, 2);
network.Connect(2, 4);
network.Connect(5, 8);

Console.WriteLine(network.Query(1, 6));
Console.WriteLine(network.Query(6, 4));
Console.WriteLine(network.Query(7, 4));
Console.WriteLine(network.Query(5, 6));

Console.ReadLine();
