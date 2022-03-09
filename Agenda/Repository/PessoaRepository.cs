using Agenda.Exceptions;
using Agenda.Models;
using System.Net;

namespace Agenda.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;
        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pessoa> CreatePessoa(Pessoa p)
        {
            if (p == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            await _context.Pessoas.AddAsync(p);
            await _context.SaveChangesAsync();
            
            return p;
        }

        public async Task<Pessoa> DeletePessoa(string nome)
        {
            if (nome == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            
            var toDelete = _context.Pessoas.FirstOrDefault(p => p.Nome.Equals(nome)); 
            if(toDelete is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa com este nome foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
            _context.Pessoas.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
           
        }

        public async Task<Pessoa> EditPessoa(Pessoa p)
        {
            if (p == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            var toUpdate = _context.Pessoas.FirstOrDefault(pp => pp.Nome == p.Nome);
            if (toUpdate is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa com este nome foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
            toUpdate.DiaNascimento = p.DiaNascimento;
            toUpdate.MesNascimento = p.MesNascimento;
            await _context.SaveChangesAsync();
            return p;
            
        }

        public async Task<List<Pessoa>> GetPessoaDiaMes(int dia, int mes)
        {
            if (dia.ToString() == null || mes.ToString() == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            var pplByDayMonth = _context.Pessoas.Where(p => p.DiaNascimento == dia && p.MesNascimento == mes).ToList();
            if (!pplByDayMonth.Any() || pplByDayMonth is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa com esta data de nascimento foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
             return pplByDayMonth;
        }

        public async Task<List<Pessoa>> GetPessoaLetra(char letraInicial)
        {
            if (letraInicial == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            var pplByFirstLetter = _context.Pessoas.Where(p => p.Nome.StartsWith(letraInicial.ToString().ToLower())).ToList();
            if (!pplByFirstLetter.Any() || pplByFirstLetter is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa com esta letra inicial foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
            return pplByFirstLetter;
            
        }

        public async Task<List<Pessoa>> GetPessoaMes(int mes)
        {

            if (mes.ToString() == null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "O Objeto não pode ser vazio.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            var pplByMonth = _context.Pessoas.Where(p => p.MesNascimento == mes).ToList(); 
            if (!pplByMonth.Any() || pplByMonth is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa foi encontrada neste mês.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
            return pplByMonth;
        }

        public async Task<List<Pessoa>> GetPessoasOrderedByMes()
        {
            
            var pplByMonthOrder = _context.Pessoas.OrderBy(m => m.MesNascimento).ToList();
            if (!pplByMonthOrder.Any() || pplByMonthOrder is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }
            return pplByMonthOrder;
        }

        public async Task<List<Pessoa>> GetPessoasOrderedByNome()
        {
            var pplByNameOrder = _context.Pessoas.OrderBy(m => m.Nome).ToList();
            if (!pplByNameOrder.Any() || pplByNameOrder is null)
            {
                throw new DefaultException(new ErrorResponse
                {
                    Message = "Nenhuma pessoa foi encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound
                }); 
            }
            return pplByNameOrder;
            
        }
    }
}
