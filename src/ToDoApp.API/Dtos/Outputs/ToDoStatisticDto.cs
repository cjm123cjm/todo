namespace ToDoApp.API.Dtos.Outputs
{
    /// <summary>
    /// 待办事项统计
    /// </summary>
    public class ToDoStatisticDto
    {
        /// <summary>
        /// 待办总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 已完成总数
        /// </summary>
        public int FinishCount { get; set; }

        /// <summary>
        /// 完成比例
        /// </summary>
        public string FinishPercent => TotalCount == 0 ? "0.00%" : (FinishCount * 100 / TotalCount).ToString("f2") + "%";
    }
}
