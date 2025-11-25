using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_presentacion.Pages.Ventanas
{
    public class SalasModel : PageModel
    {
        private ISalasPresentacion? iPresentacion = null;

        public SalasModel(ISalasPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Salas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Salas? Actual { get; set; }
        [BindProperty] public Salas? Filtro { get; set; }
        [BindProperty] public List<Salas>? Lista { get; set; }
        [BindProperty] public Salas? ActualEstado { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar() // Sino se pone el "OnPost no se llama al servicio"
        {
            try
            {
                //var variable_session = HttpContext.Session.GetString("Usuario");
                //if (String.IsNullOrEmpty(variable_session))
                //{
                //    HttpContext.Response.Redirect("/");
                //    return;
                //}

                var task = this.iPresentacion!.Listar();  
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Salas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.IdSalas.ToString() == data);
            }
            catch (Exception ex)


            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Salas>? task = null;
                if (Actual!.IdSalas == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.IdSalas.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }



        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
       

            public List<SelectListItem> Estados { get; set; } = new();


            public void OnGetEstado()
            {
                CargarEstados();
            }

            public IActionResult OnPostBtGuardarEstado()
            {
                if (ModelState.IsValid)
                {
                    // Aquí guardas en la BD
                    return RedirectToPage("Salas");
                }

                // Si hay error, recarga la lista
                CargarEstados();
                return Page();
            }

            private void CargarEstados()
            {
                Estados = new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Activo" },
                new SelectListItem { Value = "false", Text = "Inactivo" }
            };
            }
        }

    }

