﻿using CQRSAndMediatRDemoAPI.Commands;
using CQRSAndMediatRDemoAPI.Repositories;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.DeleteStudentAsync(request.Id);
        }
    }
}
