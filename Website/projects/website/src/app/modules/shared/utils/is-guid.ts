export function isGuid(obj: string): boolean {
  if (obj.substring(0, 23) == '00000000-0000-0000-0000') {
    return true;
  }
  // tslint:disable-next-line:max-line-length
  const guidRegEx: RegExp = new RegExp(
    /^(?:\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\}{0,1})$/i
  );
  return guidRegEx.test(obj);
}
