﻿// <auto-generated />
using System;
using ExampleService.Infrastructure.Adapters.Database.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleService.Migrations
{
    [DbContext(typeof(ExampleContext))]
    [Migration("20221220192513_AddDomainEventAsAbstraction")]
    partial class AddDomainEventAsAbstraction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExampleService.Domain.Events.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("events", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ExampleService.Domain.Example", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("examples", (string)null);
                });

            modelBuilder.Entity("ExampleService.Domain.Events.ExampleCreatedEvent", b =>
                {
                    b.HasBaseType("ExampleService.Domain.Events.Event");

                    b.HasDiscriminator().HasValue("ExampleCreatedEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
