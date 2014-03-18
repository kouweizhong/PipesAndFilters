namespace Pipelines
{
	public interface IPipeline<T> where T : IPipelineContract
	{
		void Run();
	}
}
