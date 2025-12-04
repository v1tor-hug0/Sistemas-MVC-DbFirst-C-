using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaJogo.Models;

[Table("TabelaJogo")]
public partial class TabelaJogo
{
    [Key]
    public int Id { get; set; }

    [StringLength(120)]
    public string Nome { get; set; } = null!;

    public int Nivel { get; set; }

    [StringLength(30)]
    public string Classe { get; set; } = null!;
}
