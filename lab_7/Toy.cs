namespace tasks
{
    /// <summary>
    /// Игрушка с атрибутами
    /// </summary>
    [Serializable]
    public struct Toy
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        
        public override string ToString() => 
            $"{Name} (Цена: {Price} руб., Возраст: {MinAge}-{MaxAge} лет)";
    }
    
}