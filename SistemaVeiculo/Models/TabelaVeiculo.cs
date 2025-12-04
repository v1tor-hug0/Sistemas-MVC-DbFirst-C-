using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaVeiculo.Models;

[Table("TabelaVeiculo")]
public partial class TabelaVeiculo
{
    [Key]
    public int Id { get; set; }

    [StringLength(120)]
    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    [StringLength(30)]
    public string Tipo { get; set; } = null!;
}
