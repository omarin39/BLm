using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessUSR
    {
        private readonly Carta_vContext _context;
        public ProcessUSR()
        {
            _context = new Carta_vContext();
        }
        private ResponseUsers ResponseWS = new();
        public DataResourceValidaciones _ParamValidaUSR = new();
        public DataEmpleados empleadoData = new();
        public DataDepartamentos departamentoData = new();
        public DataPlanta plantasData = new();
        public DataPuesto puestoData = new();
        public DataUnidadNegocio unidadNegocioData = new();
        public DataCentroCosto cecoData = new();
        public async Task<ResponseUsers> ProcesaUSER(List<RequestUsers> ReqUser, IConfiguration configuration, String ip)
        {
            ResponseWS.Mal = new();
            ResponseWS.Bien = new();
            ValidaDatosRequest ValidaDatosUs = new();
            List<ResourceValidacionesCampo> ValidaReq = await _ParamValidaUSR.FindAllDatosValida();
            //IReadOnlyList<ResourceValidacionesCampo> ValidaReq = _ParamValidaUSR.DatosValida();
            ResponseUsersValida DatosProcesados = ValidaDatosUs.ValidaRequestUSER(ReqUser, ValidaReq, configuration);

            if (DatosProcesados.Bien.Count() > 0)
            {
                ResponseWS.Bien = ExecUsr(DatosProcesados.Bien,ip);
            }
            ResponseWS.Mal= DatosProcesados.Mal;
            ResponseWS.Codigo = 200;
            return ResponseWS;
        }

        public List<ComplementosSuccessResponse> ExecUsr(List<RequestUsers> RegBien, String ip)
        {
            List<ComplementosSuccessResponse> RegistrosOk = new();
            ComplementosSuccessResponse regProcesados = new();
            foreach (var RegistroUSR in RegBien)
            {
                Empleado existe = empleadoData.FindEmpleado(RegistroUSR.NoNomina.ToString());


                switch (RegistroUSR.Operacion.ToUpper())
                {
                    case "A":


                        //empleado existe
                        if (existe != null)
                        {
                            //SI EXISTE se trata como una modificacion
                            regProcesados = UpdateUsr(RegistroUSR, existe,ip);
                            if (regProcesados != null)
                            {
                                RegistrosOk.Add(regProcesados);
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            //empleado no existe
                            regProcesados = AddUsr(RegistroUSR,ip);
                            if (regProcesados != null) {
                                RegistrosOk.Add(regProcesados);
                            }
                            else
                            {

                            }
                        }
                        break;
                    case "B":
                        //pendiente
                        break;
                    case "M":
                        regProcesados = UpdateUsr(RegistroUSR, existe,ip);
                        if (regProcesados != null)
                        {
                            RegistrosOk.Add(regProcesados);
                        }
                        else
                        {

                        }
                        break;
                }
            }


            return RegistrosOk;


        }

        public ComplementosSuccessResponse AddUsr(RequestUsers RegBien, String ip)
        {
            ComplementosSuccessResponse respAltaUsr = new();
            try
            {
                DateTime FechaIngreso;
                DateTime fechaNacimiento;
                var formatoFecha = "yyyy/mm/dd";
                DateTime.TryParseExact(RegBien.FechaIngreso, formatoFecha, null, System.Globalization.DateTimeStyles.None, out FechaIngreso);
                DateTime.TryParseExact(RegBien.FechaNacimiento, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento);
                long id_planta = FindPlanta(RegBien.IdPlanta,RegBien.AcronimoPlanta, RegBien.DescripcionPlanta,ip);
                long id_departamento = FindDepartamento(long.Parse(RegBien.id_depa_externo), RegBien.Departamento,ip);
                long id_puesto = FindPuesto(long.Parse(RegBien.id_puesto_externo), RegBien.Puesto, ip);
                long id_unidadNegocio = FindUnidadNegocio(RegBien.Unidad,ip);
                long id_CECO = FindCECO(RegBien.CeCo, RegBien.IdCeCo, RegBien.Dueno,ip);

                Empleado empleadoNewRegistro = new();
                empleadoNewRegistro.NNomina = RegBien.NoNomina.ToString();
                empleadoNewRegistro.Nombre = RegBien.Nombre;
                empleadoNewRegistro.ApellidoPaterno = RegBien.ApellidoPaterno;
                empleadoNewRegistro.ApellidoMaterno = RegBien.ApellidoMaterno;
                empleadoNewRegistro.FIngreso = FechaIngreso;
                empleadoNewRegistro.Email = RegBien.Email;
                empleadoNewRegistro.DepartamentoIdDepartamentoNivel0 = id_departamento;
                empleadoNewRegistro.PuestosIdPuesto = id_puesto;
                empleadoNewRegistro.NominaJefe = RegBien.NominaJefe.ToString();
                empleadoNewRegistro.UnidadNegocioIdUnidadNegocio = id_unidadNegocio;
                empleadoNewRegistro.FNacimiento = fechaNacimiento;
                empleadoNewRegistro.CentroCostoIdCentroCosto= id_CECO;
                empleadoNewRegistro.IdiomaIdIdioma = 1;
                empleadoNewRegistro.IdPerfil = 2;

                var respNewUSR = empleadoData.AddEmpleado(empleadoNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaUsr.Id_user = respNewUSR.ToString();
                    respAltaUsr.NoNomina = RegBien.NoNomina.ToString();
                    respAltaUsr.Operacion = RegBien.Operacion.ToString();
                    return respAltaUsr;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public ComplementosSuccessResponse UpdateUsr(RequestUsers RegBien, Empleado _Empleado, String ip)
        {
            ComplementosSuccessResponse respAltaUsr = new();
            try
            {
                DateTime FechaIngreso;
                DateTime fechaNacimiento;
                var formatoFecha = "yyyy/mm/dd";
                DateTime.TryParseExact(RegBien.FechaIngreso, formatoFecha, null, System.Globalization.DateTimeStyles.None, out FechaIngreso);
                DateTime.TryParseExact(RegBien.FechaNacimiento, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento);
                long id_planta = FindPlanta(RegBien.IdPlanta, RegBien.AcronimoPlanta, RegBien.DescripcionPlanta, ip);
                long id_departamento = FindDepartamento(long.Parse(RegBien.id_depa_externo), RegBien.Departamento, ip);
                long id_puesto = FindPuesto(long.Parse(RegBien.id_puesto_externo), RegBien.Puesto, ip);
                long id_unidadNegocio = FindUnidadNegocio(RegBien.Unidad,ip);
                long id_CECO = FindCECO(RegBien.CeCo, RegBien.IdCeCo, RegBien.Dueno,ip);

                _Empleado.NNomina = RegBien.NoNomina.ToString();
                _Empleado.Nombre = RegBien.Nombre;
                _Empleado.ApellidoPaterno = RegBien.ApellidoPaterno;
                _Empleado.ApellidoMaterno = RegBien.ApellidoMaterno;
                _Empleado.FIngreso = FechaIngreso;
                _Empleado.Email = RegBien.Email;
                _Empleado.DepartamentoIdDepartamentoNivel0 = id_departamento;
                _Empleado.PuestosIdPuesto = id_puesto;
                _Empleado.NominaJefe = RegBien.NominaJefe.ToString();
                _Empleado.UnidadNegocioIdUnidadNegocio = id_unidadNegocio;
                _Empleado.FNacimiento = fechaNacimiento;
                _Empleado.CentroCostoIdCentroCosto = id_CECO;


                var respNewUSR = empleadoData.UpdateEmpleado(_Empleado,ip);
                if (respNewUSR > 0)
                {
                    respAltaUsr.Id_user = respNewUSR.ToString();
                    respAltaUsr.NoNomina = _Empleado.NNomina.ToString();
                    respAltaUsr.Operacion = RegBien.Operacion.ToString();
                    return respAltaUsr;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public long FindPlanta(long idPlantaExt, string AcronimoPlanta, string DescPlanta,string ip){
            long idPlantaret = 0;
            var resPlanta = plantasData.FindPlanta(idPlantaExt);
            if(resPlanta!=null){
                idPlantaret=resPlanta.IdPlanta;
            }
            else
            {
                Planta newPlanta = new();
                newPlanta.Acronimo = AcronimoPlanta;
                newPlanta.IdPlantaExt = idPlantaExt;
                newPlanta.Planta1 = DescPlanta;
                var respNewPlanta = plantasData.AddPlanta(newPlanta,ip);
                idPlantaret = respNewPlanta;
            }
            return idPlantaret;
        }

        public long FindDepartamento(long idDepa_externo, string nombreDepa,string ip)
        {
            long idDepa_externoret = 0;
            //busqueda por id_externo
            var residDepa_externo = departamentoData.FindDepartamento(1,idDepa_externo, nombreDepa);
            if (residDepa_externo != null)
            {
                idDepa_externoret = residDepa_externo.IdDepartamento;
            }
            else
            {
                //busuqeda por nombre
                var seridDepaNombre= departamentoData.FindDepartamento(2, idDepa_externo, nombreDepa);
                if (seridDepaNombre!=null)
                {
                    idDepa_externoret = residDepa_externo.IdDepartamento;
                }
                else
                {
                    // se crea nuevo departamento
                    Departamento newDepartamento = new();
                    newDepartamento.Departamento1 = nombreDepa;
                    newDepartamento.IdDepartamentExt = idDepa_externo;
                    var respNewDepto = departamentoData.AddDepartamento(newDepartamento, ip);
                    idDepa_externoret = respNewDepto;
                }
                
            }
            return idDepa_externoret;
        }

        public long FindPuesto(long idPuesto_externo,string nombrePuesto,string ip)
        {
            long idPuestoret = 0;
            //busqueda por id_externo
            var resPuesto = puestoData.FindPuesto(1, idPuesto_externo, nombrePuesto);
            //Puesto existe por Puesto_ext
            if (resPuesto != null)
            {
                if(resPuesto.DescPuesto.Equals(nombrePuesto))
                {
                    idPuestoret = resPuesto.IdPuesto;
                }
                else
                {
                    resPuesto.DescPuesto = nombrePuesto;
                    resPuesto.IdPuestoExt = idPuesto_externo;
                    //_context.SaveChanges();
                    //idPuestoret = resPuesto.IdPuesto;

                    //idPuestoret = puestoData.UpdatePuesto(editPuesto); //idPuesto_externo, nombrePuesto);
                    idPuestoret = puestoData.UpdatePuesto();
                }
                
            }
            else
            {
                //busuqeda por nombre
                var serPuestoNombre = puestoData.FindPuesto(2, idPuesto_externo, nombrePuesto);
                // puesto existe
                if (serPuestoNombre != null)
                {
                    idPuestoret = serPuestoNombre.IdPuesto;
                }
                else
                {
                    // se crea nuevo puesto
                    Puesto newPuesto = new();
                    newPuesto.DescPuesto = nombrePuesto;
                    newPuesto.IdPuestoExt = idPuesto_externo;
                    var respNewPuesto = puestoData.AddPuesto(newPuesto, ip);
                    idPuestoret = respNewPuesto;
                }

            }
            return idPuestoret;
        }

        public long FindUnidadNegocio(string nombreUnidad,string ip)
        {
            long idUnidadret = 0;
            var resUnidadN = unidadNegocioData.FindUnidadNegocio(nombreUnidad);

            if (resUnidadN != null)
            {
                idUnidadret = resUnidadN.IdUnidadNegocio;
            }
            else
            {
                UnidadNegocio NewUnidadN = new();
                NewUnidadN.DescUnidadNegocio = nombreUnidad;
                var respNewUnidadN = unidadNegocioData.AddUnidadNeg(NewUnidadN, ip);
                idUnidadret = respNewUnidadN;

            }
            return idUnidadret;

        }
        public long FindCECO(string nombreCECO,long idCECO_ext, long dueno,string ip)
        {
            long idCECOret = 0;
            var resCECO = cecoData.FindCECO(nombreCECO);

            if (resCECO != null)
            {
                idCECOret = resCECO.IdCentroCosto;
            }
            else
            {
                CentroCosto NewCECO = new();
                NewCECO.DescCentroCosto = nombreCECO;
                NewCECO.DuenoCeco = dueno;
                NewCECO.IdCentroCostoExt = idCECO_ext;
                var respCECO = cecoData.AddCECO(NewCECO, ip);
                idCECOret = respCECO;

            }
            return idCECOret;

        }

    }
}
