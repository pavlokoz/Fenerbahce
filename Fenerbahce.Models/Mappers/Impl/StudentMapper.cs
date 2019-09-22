using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Linq;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class StudentMapper : IMapper<StudentEntity, StudentDTO>
	{
		private readonly IMapper<UserEntity, ParentDTO> parentMapper;
		private readonly IMapper<PaymentEntity, PaymentDTO> paymentMapper;

		public StudentMapper(IMapper<UserEntity, ParentDTO> parentMapper,
			IMapper<PaymentEntity, PaymentDTO> paymentMapper)
		{
			this.parentMapper = parentMapper;
			this.paymentMapper = paymentMapper;
		}

		public StudentEntity Map(StudentDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new StudentEntity
			{
				StudentId = source.StudentId,
				FirstName = source.FirstName,
				LastName = source.LastName,
				DateOfBirth = source.DateOfBirth,
				Patrimonial = source.Patrimonial,
				GroupId = source.GroupId
			};
		}

		public StudentDTO Map(StudentEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new StudentDTO
			{
				StudentId = source.StudentId,
				FirstName = source.FirstName,
				LastName = source.LastName,
				DateOfBirth = source.DateOfBirth,
				Patrimonial = source.Patrimonial,
				GroupId = source.GroupId,
				GroupName = source.Group?.GroupName,
				Parents = source.Parents.Select(parentMapper.Map).ToList(),
				Payments = source.Payments.Select(paymentMapper.Map).ToList()
			};
		}
	}
}
