﻿# Задания к лабораторным работам

### 1. Ознакомление к концепциями ООП: наследование и полиморфизм типов (виртуальные методы)

* Построить иерархию классов для вывода графических фигур: отрезок, прямоугольник, эллипс и т.д. - не менее 6 фигур.
* Распределить классы по модулям. Создать список фигур  в виде отдельного класса.
* В главном модуле программы добавить в список различные фигуры (статическая инициализация), после чего запустить рисование списка фигур.
* Выполнить задание на языке C++/C#.
* Для рисования использовать любую подходящую графическую библиотеку.

### 2. Графический редактор

* Расширить пример с графическими фигурами так, чтобы фигуры можно было создавать на уровне пользовательского интерфейса.
* Существуют несколько способов: ввод координат с помощью мыши, диалоговый ввод значений, ввод на скриптовом языке. Студент может выбрать любой способ ввода.
* Создание объекта должно выполняься так, чтобы добавление нового класса в систему не требовало изменения существующего кода (выбор типа с пмощью оператора case/switch и множественного if делать нельзя).
* Классы фигур не должны содержать метод рисования.
* Получившаяся программа должна представлять собой примитивный графический редактор.

### 3. Сериализация объектов

* Реализовать сериализацию/десериализацию объектов из существующей иерархии классов в файл/из файла, формат сериализации определяется индивидуальным вариантом.
* В пользовательском интерфейсе необходимо реализовать следующие функции:
  1. Возможность изменять свойства объектов (редактирование).
  2. Добавлять/удалять объекты из списка.
  3. Сериализация/десериализация списка объектов.
* Добавление новых классов в иерархию не должно пиводить к необходимости переписать существующий код, не использовать if-else/switch-case, рефлексию.
* Варианты:
  1. XML
  2. Binary
  3. Text
  4. __JSON__
  5. BSON
* Номер варианта определяетсяпо формуле: (порядковый_номер_в_группе % количество_вариантов) + 1.
