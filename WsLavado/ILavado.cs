using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsLavado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
        [ServiceContract]
        public interface ILavado
        {

        //Operaciones lavador
        [OperationContract]  
        int NuevoLavador(DatosLavador Lavador);

        [OperationContract]
        int EditarLavador(DatosLavador Lavador);

        [OperationContract]
        int EliminarLavador(int IdLavador);

        [OperationContract]
        DatosLavador BuscarLavador(int IdLavador);

        [OperationContract]
        List<DatosLavador> MostrarLavador();

        //operaciones 
        [OperationContract]
        int NuevoServicio(DatosServicio Servicio);

        [OperationContract]
        int EditarServicio(DatosServicio Servicio);

        [OperationContract]
        int EliminarServicio(int IdServicio);

        [OperationContract]
        DatosServicio BuscarServicio(int IdServicio);

        [OperationContract]
        List<DatosServicio> MostrarServicio();
        //
    }

    //establecer los contratos de cada cosa

    //Lavador
    [DataContract]
        public class DatosLavador
        {
            [DataMember]
            public int IdLavador { get; set; }
            [DataMember]
            public string NombreLavador { get; set; }
            [DataMember]
            public int TelefonoLavador { get; set; }
            [DataMember]
            public int NumeroDocumento { get; set; }
            public int EstadoRegistro { get; set; }
            public DateTime FechaRegistro { get; set; }

        }

    //Servicio
    [DataContract]
    public class DatosServicio
    {
        [DataMember]
        public int IdServicio { get; set; }
        [DataMember]
        public string Servicio { get; set; }
        [DataMember]
        public float CostoServicio { get; set; }
        public int EstadoRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

    }


}


