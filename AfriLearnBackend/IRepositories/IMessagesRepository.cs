﻿using CafrilearnBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafrilearnBackend.IRepositories;

public interface IMessagesRepository
{
    IEnumerable<Message> GetMessages();
    Message GetMessageById(int id);
    Task<Message> AddMessage(Message message);
    Task UpdateMessage(Message message);
    Task DeleteMessage(int id);
}

