using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Transactions;

namespace FP_lab1
{
    public readonly struct IPv4Address : IEquatable<IPv4Address>, IComparable<IPv4Address>
    {
        public readonly uint Raw;
        private IPv4Address(uint raw)
        {
            Raw = raw;
        }
        public static IPv4Address FromBytes(byte o1, byte o2, byte o3, byte o4) => new(((uint)o1 << 24) | ((uint)o2 << 16) | ((uint)o3 << 8) | ((uint)o4));
        public static IPv4Address FromUInt32(uint raw) => new(raw);
        public static bool TryParse(string address, out IPv4Address value)
        {
            value = default;
            if (string.IsNullOrWhiteSpace(address)) return false;
            string[] parts = address.Split('.');
            if (parts.Length != 4) return false;
            byte[] octets = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                if (!byte.TryParse(parts[i], out octets[i])) return false;
            }
            value = FromBytes(octets[0], octets[1], octets[2], octets[3]);
            return true;
        }
        public static IPv4Address Parse(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(address);
            if (!TryParse(address, out IPv4Address result)) throw new FormatException("Incorrect IPv4 format");
            return result;
        }
        public bool Equals(IPv4Address other) => Raw == other.Raw;
        public override bool Equals(object? obj) => obj is IPv4Address other && Equals(other);
        public override int GetHashCode() => Raw.GetHashCode();
        public int CompareTo(IPv4Address other) => Raw.CompareTo(other.Raw);
        public static bool operator ==(IPv4Address left, IPv4Address right) => left.Equals(right);
        public static bool operator !=(IPv4Address left, IPv4Address right) => !(left == right);
        public static bool operator <(IPv4Address left, IPv4Address right) => left.CompareTo(right) < 0;
        public static bool operator <=(IPv4Address left, IPv4Address right) => left.CompareTo(right) <= 0;
        public static bool operator >(IPv4Address left, IPv4Address right) => left.CompareTo(right) > 0;
        public static bool operator >=(IPv4Address left, IPv4Address right) => left.CompareTo(right) >= 0;
        public byte this[int octet] => (octet >= 0 && octet <= 3) ? (byte)(Raw >> ((3 - octet) * 8)) : throw new ArgumentOutOfRangeException("Argument must be from 0 to 3");
        public override string ToString() => $"{this[0]}.{this[1]}.{this[2]}.{this[3]}";
    }
}
