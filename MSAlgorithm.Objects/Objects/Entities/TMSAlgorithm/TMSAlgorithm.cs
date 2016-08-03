using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using Dacai.MagicSquareAlgorithm.Objects.Enums;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    [DataContract]
    public partial class TMSAlgorithm : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid AlgorithmId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public EAlgorithmSourceType Type { get; set; }
        [DataMember]
        public Int16 DZWeight { get; set; }
        [DataMember]
        public Int16 JCWeight { get; set; }
        [DataMember]
        public Int16 PLWeight { get; set; }
        #endregion

        #region Constructors
        public TMSAlgorithm()
        {
        }
        public TMSAlgorithm(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.AlgorithmId = new Guid(reader[nameof(this.AlgorithmId)].ToString());
            this.Name = Convert.ToString(reader[nameof(this.Name)]);
            this.Type = (EAlgorithmSourceType)Enum.Parse(typeof(EAlgorithmSourceType), reader[nameof(this.Type)].ToString());
            this.DZWeight = Convert.ToInt16(reader[nameof(this.DZWeight)]);
            this.JCWeight = Convert.ToInt16(reader[nameof(this.JCWeight)]);
            this.PLWeight = Convert.ToInt16(reader[nameof(this.PLWeight)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(AlgorithmId)))
            {
                this.AlgorithmId = new Guid(reader[nameof(this.AlgorithmId)].ToString());
            }
            if (fields.Contains(nameof(Name)))
            {
                this.Name = Convert.ToString(reader[nameof(this.Name)]);
            }
            if (fields.Contains(nameof(Type)))
            {
                this.Type = (EAlgorithmSourceType)Enum.Parse(typeof(EAlgorithmSourceType), reader[nameof(this.Type)].ToString());
            }
            if (fields.Contains(nameof(DZWeight)))
            {
                this.DZWeight = Convert.ToInt16(reader[nameof(this.DZWeight)]);
            }
            if (fields.Contains(nameof(JCWeight)))
            {
                this.JCWeight = Convert.ToInt16(reader[nameof(this.JCWeight)]);
            }
            if (fields.Contains(nameof(PLWeight)))
            {
                this.PLWeight = Convert.ToInt16(reader[nameof(this.PLWeight)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TMSAlgorithm);
            }
        }
        #endregion
    }
}
