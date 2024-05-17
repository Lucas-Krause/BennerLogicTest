namespace BennerLogicTest.Classes
{
    internal class Network
    {
        private int NumberOfElementsInSet { get; set; }

        public Dictionary<int, HashSet<int>> Connections { get; set; }

        public Network(int numberOfElementsInSet)
        {
            IsPositiveAndAboveZero(numberOfElementsInSet);
            NumberOfElementsInSet = numberOfElementsInSet;
            Connections = [];

            for (int i = 1; i <= numberOfElementsInSet; i++)
            {
                Connections.Add(i, []);
            }

        }

        public void Connect(int firstElement, int secondElement)
        {
            IsPositiveAndAboveZero(firstElement, secondElement);
            IsInsideSetRange(firstElement, secondElement);

            HashSet<int>? firstElementConnections = Connections.GetValueOrDefault(firstElement);
            HashSet<int>? secondElementConnections = Connections.GetValueOrDefault(secondElement);

            if (firstElementConnections is not null && secondElementConnections is not null)
            {
                firstElementConnections.Add(secondElement);
                secondElementConnections.Add(firstElement);
                HashSet<int> bothElementsConnections = firstElementConnections.Union(secondElementConnections).ToHashSet();

                foreach (var element in bothElementsConnections)
                {
                    HashSet<int> newElementConnections = Connections[element].ToList()
                        .Union(firstElementConnections)
                        .Union(secondElementConnections)
                        .ToHashSet();

                    newElementConnections.Remove(element);

                    Connections[element] = newElementConnections;
                }
            }
        }

        public bool Query(int firstElement, int secondElement)
        {
            IsPositiveAndAboveZero(firstElement, secondElement);
            IsInsideSetRange(firstElement, secondElement);

            return Connections[firstElement].Contains(secondElement);
        }

        private static void IsPositiveAndAboveZero(int valueForVerification)
        {
            if (valueForVerification < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(valueForVerification),
                    "Value must be positive and above zero"
                );
            }
        }

        private static void IsPositiveAndAboveZero(int valueForVerification, int secondValueForVerification)
        {
            IsPositiveAndAboveZero(valueForVerification);
            IsPositiveAndAboveZero(secondValueForVerification);
        }

        private void IsInsideSetRange(int valueForVerification)
        {
            if (valueForVerification > NumberOfElementsInSet)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(valueForVerification),
                    $"Value must be inside of set range. Current set range ({NumberOfElementsInSet})"
                );
            }
        }

        private void IsInsideSetRange(int firstElement, int secondElement)
        {
            IsInsideSetRange(firstElement);
            IsInsideSetRange(secondElement);
        }
    }
}
