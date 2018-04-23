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
  1. Добавлять/удалять объекты из списка.
  1. Сериализация/десериализация списка объектов.
* Добавление новых классов в иерархию не должно пиводить к необходимости переписать существующий код, не использовать if-else/switch-case, рефлексию.
* Варианты:
  1. XML
  1. Binary
  1. Text
  1. __*JSON*__
  1. BSON
* Номер варианта определяетсяпо формуле: (порядковый_номер_в_группе % количество_вариантов) + 1.

### 4. Плагины - иерархия

* Расширить имеющуюся иерархию новыми классами с помощью динамической загрузки модуля (плагина).
* Новые модули должны добавлять или расширять функциональность базовой программы: новый класс в иерархии, функции по работе с ним, новые элементы в пользовательском интерфейсе для работы с новым классом.
* Загружать модули можно из папки либо посредством строки-параметра в главном модуле с именем нового модуля и возможной перекомпиляцией. В идеале добавление нового модуля должно выполняться его динамической загрузкой, т.е. вообще не должно требовать изменения кода программы.
* Разработать механизм подписывания плагинов.
* Сделать подпись плагина с последующей проверкой базовой программой данной подписи на достоверность (время активации и целостность).

### 5. Плагины - функциональность

* На базе предыдущей лабораторной работы (№4) на основе плагинов (2-3 плагина) реализовать возможность обработки структур перед сохранением в файл и после загрузки из файла.
* Тип обработки задаётся вариантом.
* Дополнительная функциональность должна находиться в меню настроек и зависеть от загруженных плагинов. Загрузка плагинов производится автоматически из папки, либо выбором файла с плагином через пользовательский интерфейс.
* Предусмотреть дополнительную настройку функциональности плагина в меню настройки плагинов. Например, заданием параметров шифрования/архивации, выбор алгоритма шифрования, дополнительные правила трансформации, кодировки и т.д.
* Варианты:
  1. __*Трансформация XML данных в JSON*__
  1. Архивация
  1. Шифрование/дешифрование
  1. Трансформация XML (можно XSLI)
  1. Сохранение контрольной суммы

### 6. Паттерны

* На базе предыдущей лабораторной работы (№5) обменяться с товарищем функциональными плагинами (минимум одним) и адаптировать их в этой же работе с помощью паттерна Адаптер (т.е. появятся новые функции от плагина товарища, загруженные через плагин с адаптером).
* Также необходимо реализовать 2 паттерна (любых) в программе, пояснив уместность их использования.