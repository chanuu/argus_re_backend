using Argus.Platform.Application.Subscriptions;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Subscriptions.DTOs;
using Argus.Platform.Core.Subscriptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Subscriptions
{
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
           _subscriptionService = subscriptionService;
        }

        [HttpGet(ApiRoutes.Subscription.GetAll)]
        public async Task<IActionResult> GetAlSubscriptions()
        {
            var subscription = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscription);
        }

        [HttpGet(ApiRoutes.Subscription.Get)]
        public async Task<IActionResult> GetSubscription(Guid id)
        {
            var subscription = await _subscriptionService.GetSubscriptionAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription);
        }

        [HttpPost(ApiRoutes.Subscription.Create)]
        public async Task<IActionResult> AddSubscription(SubscriptionDto subscriptionDto)
        {

            var subscription = subscriptionDto.Adapt<Subscription>();

            var addedSubscription = await _subscriptionService.AddSubscriptionAsync(subscription);
            return CreatedAtAction(nameof(GetSubscription), new { id = addedSubscription.Id }, addedSubscription);
        }

        [HttpPut(ApiRoutes.Subscription.Create)]
        public async Task<IActionResult> UpdateSubscription(Guid id, SubscriptionDto subscriptionDto)
        {
            var existingSubscription = await _subscriptionService.GetSubscriptionAsync(id);
            if (existingSubscription == null)
            {
                return NotFound();
            }

            existingSubscription = subscriptionDto.Adapt<Subscription>();

            var updatedSubscription = await _subscriptionService.UpdateSubscriptionAsync(existingSubscription);
            return Ok(updatedSubscription);
        }
    }
}
