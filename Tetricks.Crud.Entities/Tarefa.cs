﻿using Tetricks.Crud.Entities.Abstractions;

namespace Tetricks.Crud.Entities;

public class Tarefa : ITarefa
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public required Usuario CriadoPor { get; set; }
    public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
    public Usuario? AtualizadoPor { get; set; }
    public long TenantId { get; set; }
    public required string Descricao { get; set; }
    public bool Completa { get; set; }
}
