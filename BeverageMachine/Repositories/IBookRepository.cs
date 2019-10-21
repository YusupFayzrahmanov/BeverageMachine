using BeverageMachine.Models;
using System;
using System.Collections.Generic;

namespace BeverageMachine.Repositories
{
    /// <summary>
    /// Интерфейс репозитория Book
    /// </summary>
    public interface IBookRepository:IDisposable
    {
        /// <summary>
        /// Метод получения всех книг
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Получение книги по идентификатору
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        Book GetBook(int bookID);

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"></param>
        void InsertBook(Book book);

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="bookID"></param>
        void DeleteBook(int bookID);

        /// <summary>
        /// Обновление книги
        /// </summary>
        /// <param name="book"></param>
        void UpdateBook(Book book);
        
        /// <summary>
        /// Сохранение
        /// </summary>
        void Save();
    }
}
