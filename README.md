# EffectiveMobileTestTask

## Для запуска проекта:
1. Скачайте исходные файлы одним из следующих способов:
 ![Без имени](https://github.com/user-attachments/assets/596e3144-616a-4cc7-8d0c-525862691a82)
 ![Без имени1](https://github.com/user-attachments/assets/432edcc0-606d-428b-b39d-aa2f0380abad)
2. Открыть командную строку (cmd).
3. Открыть каталог с исполняемым файлом (EffectiveMobileTestTask\EffectiveMobileTestTask\bin\Debug\net8.0).
4. Проверить, есть ли в этом каталоге файл EffectiveMobileTestTask.exe (проверить можно в cmd, используя dir)
5. Выполнить команду: EffectiveMobileTestTask.exe "Район Б" "2024-10-21 16:00:00" "[ваш путь до каталога]\EffectiveMobileTestTask\EffectiveMobileTestTask\Files\logs\delivery_log.txt" "[ваш путь до каталога]\EffectiveMobileTestTask\EffectiveMobileTestTask\Files\input\orders.csv" "[ваш путь до каталога]\EffectiveMobileTestTask\EffectiveMobileTestTask\Files\output\filtered_orders.txt"
6. Если все пройдет успешно, то выведется успешный результат.

## Для ознакомления с результатами:
1. Открыть каталог с файлами (EffectiveMobileTestTask\EffectiveMobileTestTask\Files)
2. Открыть каталог output
3. Открыть файл filtered_orders.txt

## Для ознакомления с логами:
1. Открыть каталог с файлами (EffectiveMobileTestTask\EffectiveMobileTestTask\Files)
2. Открыть каталог logs
3. Открыть файл delivery_log.txt

## Для измения входных данных:
1. Открыть каталог с файлами (EffectiveMobileTestTask\EffectiveMobileTestTask\Files)
2. Открыть каталог input
3. Изменить файл orders.csv

## Структура проекта:
Проект разделен на 5 каталогов:
1. Data - для работы с файлами
2. Files - для хранения файлов
3. Logging - логирование
4. Models - для моделей данных (в конкретном случае для заказов)
5. Services - для бизнес-логики (в конкретном случае для фильтрации)
  
   Класс Program - точка входа в программу

## Тесты:
Тесты разбиты на два класса DataServiceTests и OrderServiceTests

### DataServiceTests: 
1. LoadOrdersFromFile_ShouldReturnOrders - проверяет, что метод корректно загружает заказы из файла.
2. LoadOrdersFromFile_ShouldReturnEmptyList_WhenFileIsEmpty - проверяет, что метод возвращает пустой список, если файл с заказами пуст.
3. LoadOrdersFromFile_ShouldReturnEmptyList_WhenFileIsInvalid - проверяет, что метод возвращает пустой список, если файл содержит некорректные данные.

### OrderServiceTests: 
1. FilterOrders_ShouldReturnCorrectOrders - проверяет, что метод корректно фильтрует заказы по указанному району и времени.
2. FilterOrders_ShouldReturnEmpty_WhenNoOrdersInSpecifiedDistrict - проверяет, что метод возвращает пустой результат, если в указанном районе нет подходящих заказов.
3. FilterOrders_ShouldReturnOrdersWithin30MinutesTimeRange - проверяет, что метод возвращает заказы, которые попадают в 30-минутный временной диапазон, начиная с указанного времени доставки. В данном тесте ожидается 3 заказа, соответствующих условиям.
