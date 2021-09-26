export class BookResourceRequest {
  constructor(
    public startDate: Date,
    public endDate: Date,
    public bookedQuantity: number
  ) {}
}
