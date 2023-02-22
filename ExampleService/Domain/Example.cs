﻿using System.Reflection.Metadata;
using Common.Domain;
using Common.Events;
using Common.Events.ExampleService;
using ExampleService.Application.Commands.ChangeNameOfExample;
using ExampleService.Domain.BusinessRules;
using Wrappit.Messaging;

namespace ExampleService.Domain;

public class Example : AggregateRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Example(IEnumerable<Event> events) : base(events) { }
    public Example()
    {
        var id = Guid.NewGuid();
        
        Events.Add(new ExampleCreatedEvent(id));
    }

    public void ChangeName(ChangeNameOfExampleCommand command)
    {
        command.NameCannotBeLongerThan10Characters();
        
        Events.Add(new NameChangedEvent(Id, command.Name));
    }

    protected override void When(dynamic evt)
    {
        Handle(evt);
    }

    private void Handle(ExampleCreatedEvent evt)
    {
        Id = evt.Id;
    }

    private void Handle(NameChangedEvent evt)
    {
        Name = evt.Name;
    }
}