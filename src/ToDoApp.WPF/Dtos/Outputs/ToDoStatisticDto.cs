namespace ToDoApp.WPF.Dtos.Outputs
{
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
        public string? FinishPercent { get; set; }
    }
}
