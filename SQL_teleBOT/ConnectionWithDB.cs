using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SQL_teleBOT
{
    static class ConnectionWithDB
    {
        public static void CreateDB()
        {
            if (File.Exists(@"C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db"))
                Console.WriteLine("DB exists");
            else
            {
                SQLiteConnection.CreateFile(@"C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db");
                Console.WriteLine("DB was created successfully");
                SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db; Version=3;");
                connect.Open(); 
                SQLiteCommand command;

                command = new SQLiteCommand(
                "CREATE TABLE \"Messages\" (\"id\" INTEGER PRIMARY KEY AUTOINCREMENT, \"nickname\" TEXT, \"messageText\" TEXT)", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand(
                "CREATE TABLE \"operatorsInSQL\" (\"operator\" TEXT PRIMARY KEY, \"info\" TEXT)", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"CREATE TABLE\"', '\"Данный оператор позволяет создавать и определять таблицу," +
               " синтаксис: CREATE TABLE [название таблицы] ([название столбца 1] [аргументы], [название столбца 2]" +
               " [аргументы], ...);\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"INSERT INTO\"', '\"Данный оператор используется для вставки новых строк в таблицу (внесения данных в таблицу), синтаксис: INSERT INTO [название таблицы] ([название столбца 1], [название столбца 2], ...) VALUES ([значение 1], [значение 2], ...);\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"SELECT\"', '\"Данный оператор используется для запросов к базе данных с целью извлечения из нее информации (вывод на экран значения/значений таблицы), синтаксис: SELECT [название столбца 1, название столбца 2, ...] FROM [название таблицы] WHERE ... ORDER BY ...;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"WHERE\"', '\"Оператор WHERE задает условие, по которому будут выбираться строки из базы данных. Данная команда может использоваться для выборки строк с помощью SELECT, удаления строк с помощью DELETE, редактирования строк с помощью UPDATE.\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"ORDER BY\"', '\"Команда ORDER BY позволяет сортировать записи по определенному полю при выборе из базы данных, используется с оператором SELECT.\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"*\"', '\"* используется в операторе SELECT для выбора всей записей таблицы, пример использования: SELECT * FROM months;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"DISTINCT\"', '\"DISTINCT используется с SELECT для вывода значений из столбца без повторений, пример использования: SELECT DISTINCT name FROM months;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"AUTOINCREMENT\"', '\"AUTOINCREMENT - свойство, которое позволяет создавать уникальный номер для каждой записи автоматически. По умолчанию начальное значения для атрибута автоинкремента равно 1, для каждой новой записи значение увеличивается на 1. Пример использования: CREATE TABLE months (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, days INTEGER);\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"PRIMARY KEY\"', '\"PRIMARY KEY — первичный ключ, ограничение, позволяющее однозначно идентифицировать каждую запись в таблице SQL (определяет ключевое поле), пример использования: CREATE TABLE users (id INTEGER PRIMARY KEY); Дополнение: СУБД не позволит вам создать копию значения из ключевого поля, так как каждое значение ключевого поля уникально. Также не получится записать значение NULL в ключевое поле. Поле с атрибутом PRIMARY KEY автоматически имеет ограничение NOT NULL.\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"UPDATE\"', '\"Данный оператор производит изменения в уже существующей записи или во множестве записей (обновляет элемент в таблице), синтаксис: UPDATE [название таблицы] SET [название столбца] = ... WHERE [условие обзора];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"DELETE FROM\"', '\"Данный оператор удаляет одну или несколько строк в таблице, синтаксис: DELETE FROM [название таблицы] WHERE [условие обзора];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"DROP TABLE\"', '\"Данный оператор удаляет таблицу, синтаксис: DROP TABLE [название таблицы];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"MIN\"', '\"Функция MIN возвращает минимальное значение поля среди найденных строк, синтаксис: SELECT MIN(поле) FROM имя_таблицы WHERE условие;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"MAX\"', '\"Функция MAX возвращает максимальное значение поля среди найденных строк, синтаксис: SELECT MAX(поле) FROM имя_таблицы WHERE условие;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"COUNT\"', '\"Функция COUNT подсчитывает количество записей в таблице, синтаксис: SELECT COUNT(поле) FROM имя_таблицы WHERE условие\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"SUM\"', '\"Функция SUM суммирует значения указанного поля по всем выбранным строкам, синтаксис: SELECT SUM(поле) FROM имя_таблицы WHERE условие;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"AVG\"', '\"Функция AVG возвращает среднее арифметическое по всем найденным записям, синтаксис: SELECT AVG(поле) FROM имя_таблицы WHERE условие;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"GROUP BY\"', '\"Команда GROUP BY позволяет группировать результаты при выборке из базы данных, синтаксис SELECT * FROM имя_таблицы WHERE условие GROUP BY поле_для_группировки\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"LIMIT\"', '\"Команда LIMIT задает ограничение на количество записей, выбираемых из базы данных. Данная команда может использоваться совместно с командой SELECT, командой DELETE, и командой UPDATE.\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"OFFSET\"', '\"Использование команды OFFSET позволяет пропустить указанное количество строк перед тем как выводить результаты запроса, пример использования: SELECT * FROM название таблицы LIMIT 10 OFFSET 14;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"ALTER TABLE\"', '\"Команда ALTER TABLE используется для добавления (используем ADD), удаления (используем DROP) или модификации (например, переименовываем, используя RENAME TO) колонки в уже существующей таблице, примеры использования: ALTER TABLE имя таблицы RENAME TO новое имя таблицы; ALTER TABLE имя таблицы ADD COLUMN название столбца [тип данных столбца];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"NOT NULL\"', '\"NOT NULL - ограничение, при котором запись или записи не могут равняться значению NULL. СУБД не позволит вам создать запись со значением NULL в конкретном поле, если у данного поля имеется атрибут NOT NULL. Примеры использования: \nСоздание таблицы с полем, требующим отсутствия незаполненных ячеек в рамках данного поля: CREATE TABLE users(id INTEGER PRIMARY KEY, contact TEXT NOT NULL); \nВыборка всех записей из таблицы users, у которых в поле contact отсутствует значение NULL: SELECT * FROM users WHERE contact IS NOT NULL;\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"UNIQUE\"', '\"Атрибут UNIQUE - ограничение, при котором создание двух одинаковых ячеек в рамках одного поля становится невозможным.  Значения ячеек в рамках поля с атрибутом UNIQUE могут равняться NULL. В этом состоит его главное отличие от атрибута ключевого поля. Пример использования: CREATE TABLE users (id INTEGER PRIMARY KEY, contact TEXT UNIQUE);\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"LIKE\"', '\"Оператор LIKE используется в предложении WHERE для поиска заданного шаблона в столбце. Синтаксис: SELECT [название столбцов] FROM [название таблицы] WHERE [название столбца] LIKE [условие];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"GLOB\"', '\"Оператор GLOB используется для сопоставления только текстовых значений с шаблоном с использованием подстановочных знаков. Синтаксис: SELECT [название столбцов] FROM [название таблицы] WHERE [название столбца] GLOB [условие];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"UNION\"', '\"Оператор UNION используется для объединения результирующего набора из двух или более операторов SELECT. Чтобы использовать оператор UNION, каждый SELECT обязан иметь одинаковое количество выбранных столбцов с одинаковыми типами данных. Записи выведутся без повторений. Синтаксис:\nSELECT[название столбцов] FROM[название таблицы] [WHERE[название столбца]]\nUNION\nSELECT[название столбцов] FROM[название таблицы] [WHERE[название столбца]];\"')", connect);
                command.ExecuteNonQuery();

                command = new SQLiteCommand("INSERT INTO \"operatorsInSQL\"(\"operator\", \"info\") " +
               "VALUES ('\"UNION ALL\"', '\"Оператор UNION по умолчанию выбирает только разные значения. Чтобы разрешить повторяющиеся значения, используйте UNION ALL. Синтаксис:\nSELECT[название столбцов] FROM[название таблицы] [WHERE[название столбца]]\nUNION ALL\nSELECT[название столбцов] FROM[название таблицы] [WHERE[название столбца]];\"')", connect);
                command.ExecuteNonQuery();

                connect.Close();
            }
        }

        public static string WhatOperator(string s)
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db; Version=3;");
            connect.Open();
            SQLiteCommand command;
            command = new SQLiteCommand("SELECT \"info\" FROM \"operatorsInSQL\" WHERE \"operator\" = '\"" + s + "\"'", connect);
            SQLiteDataReader reader;
            string result = "";
            reader = command.ExecuteReader(); 
            while (reader.Read())
            {
                result = reader["info"].ToString();
            }
            reader.Close(); 
            connect.Close();
            result = result.Trim('"');
            return result;
        }

        public static void Input(string nickname, string messageText)
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db; Version=3;");
            connect.Open();
            SQLiteCommand command;
            command = new SQLiteCommand("INSERT INTO \"Messages\"(\"nickname\", \"messageText\") " +
               "VALUES ('" + nickname + "', '" + messageText + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }
        public static string getMessages()
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Прог\repositorySQL\LearnSQL_telegramBot\DataBase.db; Version=3;");
            connect.Open();
            SQLiteCommand command;
            command = new SQLiteCommand("SELECT * FROM \"Messages\"", connect);
            SQLiteDataReader reader;
            string result = "";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += (@"
" +reader["nickname"].ToString() + " написал: \"" + reader["messageText"].ToString() + "\"");
            }
            reader.Close();
            connect.Close();
            return result;
        }
    }
}

