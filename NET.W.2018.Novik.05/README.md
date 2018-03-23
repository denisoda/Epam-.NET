## Задание 1.

Разработать неизменяемый класс Polynomial (полином) для работы с многочленами степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса 
1. переопределить виртуальные методы класса Object; 
2. перегрузить операции, допустимые для работы с многочленами (исключая деление многочлена на многочлен), включая “==” и “!=”. 
Разработать unit-тесты. 

### Файлы

* [Polynomial.cs](/NET.W.2018.Novik.05/Logic/Polynomial.cs) - Implementation
* [Polynomial.Operations.cs](/NET.W.2018.Novik.05/Logic/Polynomial.Operations.cs) - Implementation operations
* [PolynomialBaseFuncTests.cs](/NET.W.2018.Novik.05/Logic.UnitTests/PolynomialTests/PolynomialBaseFuncTests.cs) - Tests (NUnit)
* [PolynomialOperationTests.cs](/NET.W.2018.Novik.05/Logic.UnitTests/PolynomialTests/PolynomialOperationTests.cs) - Tests operations (NUnit)


### Задание 2.


Реализовать алгоритм “пузырьковой” сортировки непрямоугольного (jagged array) целочисленного массива (методы сортировки класса System.Array не использовать) таким образом, чтобы была возможность упорядочить строки матрицы: 
1. в порядке возрастания (убывания) сумм элементов строк матрицы; 
2. в порядке возрастания (убывания) максимальных элементов строк матрицы; 
3. в порядке возрастания (убывания) минимальных элементов строк матрицы; 
Разработать unit-тесты. 

### Файлы

* [BubbleSort.cs](/NET.W.2018.Novik.05/Logic/BubbleSort.cs) - Implementation
* [BubbleSortTests.cs](/NET.W.2018.Novik.05/Logic.UnitTests/BubbleSortTests.cs) - Tests (NUnit)