using AutoMapper;
using MediatR;
using MyProject.Core.Features.Students.Queries.Models;
using MyProject.Core.Features.Students.Queries.Results;
using MyProject.Core.Generic_Response;
using MyProject.Core.Wrapper;
using MyProject.Data.Entities;
using MyProject.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Queries.Handlers
{
    public class GetStudentQueryHandler : ResponseHandler
        , IRequestHandler<GetStudentPaginationListQuery, PaginationResult<GetStudentPaginatedListResponse>>
        , IRequestHandler<GetStudentListQuery, Response<List<ModelGetStudentListMapping>>>
        , IRequestHandler<GetStudentQueryByID, Response<ModelGetStudentMapping>>
    {
        private readonly IStudentServiece _studentServiece;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IStudentServiece serviece, IMapper mapper)
        {
            _studentServiece = serviece;
            _mapper = mapper;
        }
        public async Task<Response<List<ModelGetStudentListMapping>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentsResult = await _studentServiece.GetStudentsListAsync();
            var map = _mapper.Map<List<ModelGetStudentListMapping>>(studentsResult);
            return Success(map);
        }

        public async Task<Response<ModelGetStudentMapping>> Handle(GetStudentQueryByID request, CancellationToken cancellationToken)
        {
            var student = await _studentServiece.GetStudentByIdAsync(request.StudentId);
            if (student == null) return NotFound<ModelGetStudentMapping>();

            var map = _mapper.Map<ModelGetStudentMapping>(student);
            return Success(map);

        }

        public async Task<PaginationResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginationListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudentId, e.Name, e.Adress, e.Department.Name);

            var filterQueryableStudent = _studentServiece.FilterGetStudentPaginatedQueryable(request.Search);

            var paginationList = await filterQueryableStudent.Select(expression).ToPaginationListAsync(request.PageNumber, request.PageSize);

            return paginationList;



        }
    }
}
