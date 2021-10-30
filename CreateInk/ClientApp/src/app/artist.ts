export class Artist{
    id: string;
    firstName: string;
    lastName: string;
    age: number;
    arts: [
      {
        id: string;
        name: string;
        description:string
        date: Date;
        artistId: string;
      }
    ];
    description: string;
    role: string;
    email: string;
    username: string;
    password:string;
}