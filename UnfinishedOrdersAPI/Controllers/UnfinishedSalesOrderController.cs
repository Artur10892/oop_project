using AutoMapper;
using Common.Events.OrderEvents;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using UnfinishedOrdersAPI.Entities;
using UnfinishedOrdersAPI.Exceptions;
using UnfinishedOrdersAPI.Repositories.Abstract;

namespace UnfinishedOrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnfinishedSalesOrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        
        private readonly IUnfinishedSalesOrderRepository _unfinishedSalesOrderRepository;
        
        private readonly IPublishEndpoint _publishEndpoint;

        public UnfinishedSalesOrderController(IMapper mapper, IUnfinishedSalesOrderRepository unfinishedSalesOrderRepository, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _unfinishedSalesOrderRepository = unfinishedSalesOrderRepository;
            _publishEndpoint = publishEndpoint;
        }
        
        // GET: api/UnfinishedSalesOrder
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UnfinishedSalesOrder>>> Get()
        {
            try
            {
                var results = await _unfinishedSalesOrderRepository.GetAllAsync();
                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
        
        // GET: api/UnfinishedSalesOrder/5
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UnfinishedSalesOrder?>> Get(string orderId)
        {
            try
            {
                var result = await _unfinishedSalesOrderRepository.GetAsync(orderId);
                return Ok(result);
            }
            catch (UnfinishedOrderNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, new {e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        //POST: api/UnfinishedSalesOrder/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> AddUnfinishedSalesOrder()
        {
            try
            {
                var initialUnfinishedSalesOrder = new UnfinishedSalesOrder();
                var insertedId = await _unfinishedSalesOrderRepository.InsertAsync(initialUnfinishedSalesOrder);
                return Ok(insertedId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        // PUT: api/UnfinishedSalesOrder
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUnfinishedSalesOrder([FromBody] UnfinishedSalesOrder unfinishedSalesOrder)
        {
            try
            {
                await _unfinishedSalesOrderRepository.UpdateAsync(unfinishedSalesOrder);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        // DELETE: api/UnfinishedSalesOrder
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUnfinishedSalesOrder(string id)
        {
            try
            {
                await _unfinishedSalesOrderRepository.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
        
        // POST: api/UnfinishedSalesOrder/FinishOrder
        [HttpPost("FinishOrder/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> FinishSalesOrder(string orderId)
        {
            try
            {
                var unfinishedSalesOrder = await _unfinishedSalesOrderRepository.GetAsync(orderId);

                // send finished appointment event to rabbitmq
                var eventMessage = _mapper.Map<FinishedSalesOrderEvent>(unfinishedSalesOrder);
                await _publishEndpoint.Publish(eventMessage);
                
                await _unfinishedSalesOrderRepository.DeleteByIdAsync(orderId);
                return Ok();
            }
            catch (UnfinishedOrderNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, new {e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
            }
        }
    }
}
